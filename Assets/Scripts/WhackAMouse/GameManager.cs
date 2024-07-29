using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace whackAMouse
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<Rat> rats;

        [Header("UI Objects")]
        [SerializeField] private GameObject playButton;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private GameObject outOfTimeText;
        [SerializeField] private GameObject cactusFailText;
        [SerializeField] private TMPro.TextMeshProUGUI timeText;
        [SerializeField] private TMPro.TextMeshProUGUI scoreText;


        //initial amount of time
        private float startingTime = 30f;

        private float remainingTime;
        private HashSet<Rat> currentRats = new HashSet<Rat>();
        private int score;
        private bool playing = false;


        public void StartGame()
        {
            // Hide/show the UI elements we don't/do want to see.
            playButton.SetActive(false);
            outOfTimeText.SetActive(false);
            cactusFailText.SetActive(false);
            gameUI.SetActive(true);

            // Hide all the visible rats.
            for (int i = 0; i < rats.Count; i++)
            {
                rats[i].Hide();
                rats[i].SetIndex(i);
            }
            // Remove any old game state.
            currentRats.Clear();
            // Start with 30 seconds.
            remainingTime = startingTime;
            score = 0;
            scoreText.text = "0";
            playing = true;
        }

        public void AddScore(int ratIndex)
        {
            //add to and update score
            score += 1;
            scoreText.text = $"{score}";
            //increase time by one second
            remainingTime += 1;
            //remove from active rats
            currentRats.Remove(rats[ratIndex]);
        }

        public void Missed(int ratIndex, bool isRat)
        {
            if (isRat)
            {
                remainingTime -= 2;
            }
            currentRats.Remove(rats[ratIndex]);
        }

        public void GameOver(int type)
        {
            //Show game over message.
            if (type == 0)
            {
                outOfTimeText.SetActive(true);
            }
            else
            {
                cactusFailText.SetActive(true);
            }
            // Hide all moles.
            foreach (Rat rat in rats)
            {
                rat.StopGame();
            }
            // Stop the game and show the start UI.
            playing = false;
            playButton.SetActive(true);
        }

        void Update()
        {
            if (playing)
            {
                // Update time.
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 0)
                {
                    remainingTime = 0;
                    GameOver(0);
                }
                timeText.text = $"{(int)remainingTime / 60}:{(int)remainingTime % 60:D2}";
                // Check if we need to start any more moles.
                if (currentRats.Count <= (score / 10))
                {
                    // Choose a random rat.
                    int index = Random.Range(0, rats.Count);
                    // Doesn't matter if it's already doing something, we'll just try again next frame.
                    if (!currentRats.Contains(rats[index]))
                    {
                        currentRats.Add(rats[index]);
                        rats[index].Activate(score / 10);
                    }
                }
            }
        }
    }
}
