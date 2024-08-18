using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using whackAMouse;

namespace whackAMouse
{

    public class Rat : MonoBehaviour
    {
        [Header("Graphics")]
        [SerializeField] private Sprite rat;
        [SerializeField] private Sprite ratCrossEyes;
        [SerializeField] private Sprite redEyesRat;
        [SerializeField] private Sprite redEyesRatHit;
        [SerializeField] private Sprite RedRatCrossEyes;
        [SerializeField] private Sprite Cactus;


        [Header("GameManager")]
        [SerializeField] private GameManager gameManager;

        // The offset of the sprite to hide it.
        private Vector2 startPosition = new Vector2(0f, -8.4f);
        private Vector2 endPosition = new Vector2(0f, 0.55f);
        // How long it takes to show a mole.
        private float showDuration = 0.5f;
        private float duration = 1f;

        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2D;
        private Vector2 boxOffset;
        private Vector2 boxSize;
        private Vector2 boxOffsetHidden;
        private Vector2 boxSizeHidden;

        // Mole Parameters 
        private bool hittable = true;
        public enum RatType { Normal, RedEyes, Cactus };
        private RatType ratType;
        private float redEyesRate = 0.25f;
        private float cactusRate = 0f;
        private int lives;
        private int ratIndex = 0;

        [Header("Audio")]
        [SerializeField] private AudioClip ratSound;
        [SerializeField] private AudioClip cactusSound;
        private AudioSource audioSource;

        private IEnumerator ShowHide(Vector2 start, Vector2 end)
        {
            // Make rat is at the start.
            transform.localPosition = start;

            // Show the rat.
            float elapsed = 0f;
            while (elapsed < showDuration)
            {
                transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
                boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
                boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
                // Update at max framerate.
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Make sure rat is at the end.
            transform.localPosition = end;
            boxCollider2D.offset = boxOffset;
            boxCollider2D.size = boxSize;

            // Wait for duration to pass.
            yield return new WaitForSeconds(duration);

            // Hide the rat.
            elapsed = 0f;
            while (elapsed < showDuration)
            {
                transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
                boxCollider2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);
                boxCollider2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);
                // Update at max framerate.
                elapsed += Time.deltaTime;
                yield return null;
            }
            // Make rat is at the start.
            transform.localPosition = start;
            boxCollider2D.offset = boxOffsetHidden;
            boxCollider2D.size = boxSizeHidden;

            // If it gets to the end and it's still hittable then it was missed.
            if (hittable)
            {
                hittable = false;
                // Only give time penalty if it isn't a cactus.
                gameManager.Missed(ratIndex, ratType != RatType.Cactus);
            }
        }

        public void Hide()
        {
            // Set rat parameters to hide it.
            transform.localPosition = startPosition;
            boxCollider2D.offset = boxOffsetHidden;
            boxCollider2D.size = boxSizeHidden;
        }

        private IEnumerator QuickHide()
        {
            yield return new WaitForSeconds(0.25f);
            // While we were waiting we may have spawned again here, so just
            // check that hasn't happened before hiding it. This will stop it
            // flickering in that case.
            if (!hittable)
            {
                Hide();
            }
        }

        private void OnMouseDown()
        {
            if (hittable)
            {
                switch (ratType)
                {
                    case RatType.Normal:
                        spriteRenderer.sprite = ratCrossEyes;
                        gameManager.AddScore(ratIndex);
                        audioSource.clip = ratSound;
                        audioSource.Play();
                        // Stop the animation
                        StopAllCoroutines();
                        StartCoroutine(QuickHide());
                        // Turn off hittable so it can't keep being tapped for score.
                        hittable = false;
                        break;
                    case RatType.RedEyes:
                        // If lives == 2 reduce, and change sprite.
                        if (lives == 2)
                        {
                            spriteRenderer.sprite = redEyesRatHit;
                            lives--;
                        }
                        else
                        {
                            spriteRenderer.sprite = RedRatCrossEyes;
                            gameManager.AddScore(ratIndex);

                            audioSource.clip = ratSound;
                            audioSource.Play();
                            // Stop the animation
                            StopAllCoroutines();
                            StartCoroutine(QuickHide());
                            // Turn off hittable so it can't keep being tapped for score.
                            hittable = false;
                        }
                        break;
                    case RatType.Cactus:
                        // Game over, 1 for cactus.
                        gameManager.GameOver(1);
                        audioSource.clip = cactusSound;
                        audioSource.Play();
                        break;
                    default:
                        break;
                }
            }
        }

        private void CreateNext()
        {
            float random = Random.Range(0f, 1f);
            if (random < cactusRate)
            {
                // Make a cactus.
                ratType = RatType.Cactus;
                spriteRenderer.sprite = Cactus;
            }
            else
            {
                random = Random.Range(0f, 1f);
                if (random < redEyesRate)
                {
                    // Create a red eyes rat.
                    ratType = RatType.RedEyes;
                    spriteRenderer.sprite = redEyesRat;
                    lives = 2;
                }
                else
                {
                    // Create a normal rat.
                    ratType = RatType.Normal;
                    spriteRenderer.sprite = rat;
                    lives = 1;
                }
            }
            // Mark as hittable so an onclick event can be rigestered.
            hittable = true;
        }

        // As the level progresses the game gets harder.
        private void SetLevel(int level)
        {
            // As level increases increse the cactus rate to 0.25 at level 10.
            cactusRate = Mathf.Min(level * 0.025f, 0.25f);

            // Increase the amounts of RedEyesRats until 100% at level 40.
            redEyesRate = Mathf.Min(level * 0.025f, 1f);

            // Duration bounds get quicker as we progress. No cap on insanity.
            float durationMin = Mathf.Clamp(1 - level * 0.1f, 0.01f, 1f);
            float durationMax = Mathf.Clamp(2 - level * 0.1f, 0.01f, 2f);
            duration = Random.Range(durationMin, durationMax);
        }

        private void Awake()
        {
            // Get references to the components needed.
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            audioSource = GetComponent<AudioSource>();
            // Work out collider values.
            boxOffset = boxCollider2D.offset;
            boxSize = boxCollider2D.size;
            boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
            boxSizeHidden = new Vector2(boxSize.x, 0f);
            audioSource = GetComponent<AudioSource>();
        }

        public void Activate(int level)
        {
            SetLevel(level);
            CreateNext();
            StartCoroutine(ShowHide(startPosition, endPosition));
        }

        // Used by the game manager to identify rats. 
        public void SetIndex(int index)
        {
            ratIndex = index;
        }

        // Used to freeze the game on finish.
        public void StopGame()
        {
            hittable = false;
            StopAllCoroutines();
        }
    }


}