using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dunkADog
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private int score = 0;
        private int level = 1;
        public int amountOfThrows = 5;
        private bool playing = false;
        
        public GameObject ballPrefab;
        public Sprite[] ballSprites; 
        public Vector3 spawnPosition;

        private Target target;
        public GameObject spriteToRotate;
        public GameObject spriteToFall;
        public Rigidbody2D rigidBody2d;
        



        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindObjectOfType<Target>();
            amountOfThrows = 5;

            
            StartGame(); // REMOVE LATER
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartGame()
        {
            playing = true;
            level = 1;
            score = 0;
            Debug.Log("Game Started. Initial Level: " + level + " Current Score: " + score);

            SpawnBall();
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Missed()
        {
            if (amountOfThrows > 0)
            {
                amountOfThrows--;
            }
            if (amountOfThrows <= 0)
            {
                GameOver();
            }
        }


        public void LevelUp()
        {
            level++;
            Debug.Log("Level Up called. Current Level: " + level);

            target.frequency++;
            Debug.Log("Speed Increase called. Current speed: " + target.frequency);

            AddScore();
            Debug.Log("Current Score: " + score);

            if (level == 6)
            {

                Victory();
            }
        }
        public void SpawnBall()
        {
            if (ballPrefab != null && amountOfThrows > 0)
            {
                GameObject ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

                // Get the SpriteRenderer component
                SpriteRenderer spriteRenderer = ball.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null && ballSprites.Length > 0)
                {
                    // Assign a random sprite from the array
                    spriteRenderer.sprite = ballSprites[Random.Range(0, ballSprites.Length)];
                }

                target.ResetHitStatus();
            }
        }

        void AddScore()
        {
            score = score + 20;
        }

        void GameOver()
        {
            Debug.Log("Game Over! Out of Throws");
            StopTargetMovement();
            ResetTargetPosition();
        }

        void Victory()
        {
            if (spriteToRotate != null)
            {
                spriteToRotate.transform.Rotate(new Vector3(0, 0, 90));    
            }
            
            StopTargetMovement();
            ResetTargetPosition();
            playing = false;
        }
        public void StopTargetMovement()
        {
            if (target != null)
            {
                target.StopMovement();
            }
        }

        public void ResetTargetPosition()
        {
            if (target != null)
            {
                target.ResetPosition();
            }
        }
    }
}
