using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite rat;
    [SerializeField] private Sprite ratCrossEyes;
    [SerializeField] private Sprite ratRedEyes;
    [SerializeField] private Sprite ratRedEyesHit;
    [SerializeField] private Sprite ratRedCrossEyes;
    [SerializeField] private Sprite cactus;

    private bool hittable = true;

    public enum RatType { Normal, RedEyes, Cactus };
    private RatType ratType;
    private float redEyeRate = 0.25f;
    private float cactusRate = 0f;
    private int lives;

    //start and end location for rat popping up and down
    private Vector2 startPosition = new Vector2(0f, -8.4f);
    private Vector2 endPosition = new Vector2(0f, 0.55f);

    //how long the mole shows for
    private float showDuration = 0.5f;
    private float duration = 1f;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Vector2 boxOffset;
    private Vector2 boxSize;
    private Vector2 boxOffsetHidden;
    private Vector2 boxSizeHidden;

    private void CreateNext()
    {
        //creates a cactus if random number is within set range
        float random = Random.Range(0f, 1f);
        if (random < cactusRate)
        {
            ratType = RatType.Cactus;
        }
        else
        {
            //creates a red eyes rat if random number is within set range
            random = Random.Range(0f, 1f);
            if (random < redEyeRate)
            {
                ratType = RatType.RedEyes;
                spriteRenderer.sprite = ratRedEyes;
                lives = 2;
            }
            else
            {
                //creates a red eyes rat if other options aren't selected
                ratType = RatType.Normal;
                spriteRenderer.sprite = rat;
                lives = 1;
            }
        }
        hittable = true;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        //work out rat box collider values
        boxOffset = boxCollider2D.offset;
        boxSize = boxCollider2D.size;
        boxOffsetHidden = new Vector2(boxOffset.x, -startPosition.y / 2f);
        boxSizeHidden = new Vector2(boxSize.x, 0f);
    }

    private void OnMouseDown()
    {
        if (hittable)
        {
            switch (ratType)
            {
                case RatType.Normal:
                    spriteRenderer.sprite = ratCrossEyes;
                    //stop the animation
                    StopAllCoroutines();
                    StartCoroutine(QuickHide());
                    hittable = false;
                    break;
                case RatType.RedEyes:
                    //if lives == 2 reduce, and change sprite
                    if (lives == 2)
                    {
                        spriteRenderer.sprite = ratRedEyesHit;
                        lives--;
                    }
                    else
                    {
                        spriteRenderer.sprite = ratRedCrossEyes;
                        //stop the animation
                        StopAllCoroutines();
                        StartCoroutine(QuickHide());
                        hittable = false;
                    }
                    break;
                case RatType.Cactus:
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);
        if (!hittable)
        {
            Hide();
        }
    }

    public void Hide()
    {
        transform.localPosition = startPosition;
        boxCollider2D.offset = boxOffsetHidden;
        boxCollider2D.size = boxSizeHidden;
    }


    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        //make sure rat is at start
        transform.localPosition = start;

        //showing the rat
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffsetHidden, boxOffset, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSizeHidden, boxSize, elapsed / showDuration);
            //update at max framerate
            elapsed += Time.deltaTime;
            yield return null;
        }
        //make sure rat is at end
        transform.localPosition = end;

        //wait for duration to pass
        yield return new WaitForSeconds(duration);

        //hide the rat
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            boxCollider2D.offset = Vector2.Lerp(boxOffset, boxOffsetHidden, elapsed / showDuration);
            boxCollider2D.size = Vector2.Lerp(boxSize, boxSizeHidden, elapsed / showDuration);

            //update at max framrate
            elapsed += Time.deltaTime;
            yield return null;
        }
        //make sure rat is at start
        transform.localPosition = start;
        boxCollider2D.offset = boxOffsetHidden; 
        boxCollider2D.size = boxSizeHidden;
    }

    private void SetLevel(int level)
    {
        //as level increases cactus rate increases
        cactusRate = Mathf.Min(level * 0.025f, 0.25f);

        //as level increases red eyes rat rate increases
        redEyeRate = Mathf.Min(level * 0.025f, 1f);

        //rat visibility duration gets shorter as level increases
        float durationMin = Mathf.Clamp(1 - level * 0.1f, 0.01f, 1f);
        float durationMax = Mathf.Clamp(2 - level * 0.1f, 0.01f, 2f);
        duration = Random.Range(durationMin, durationMax);
    }


    // Start is called before the first frame update
    public void Activate(int level)
    {
        SetLevel(level);
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    }
}
  
