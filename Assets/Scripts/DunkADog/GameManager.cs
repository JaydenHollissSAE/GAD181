using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dunkADog
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private int score;
        private int level = 1;
        public int amountOfThrows = 5;
        private bool playing = false;

        public GameObject ballPrefab;
        public Vector3 spawnPosition;

        private Target target;



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
            Debug.Log("Game Started. Initial Level: " + level);

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
        }
        public void SpawnBall()
        {
            if (ballPrefab != null && amountOfThrows > 0)
            {
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            }
            target.ResetHitStatus();
            
        }
        void GameOver()
        {
            Debug.Log("Game Over! Out of Throws");
        }
    }
}
