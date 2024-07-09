using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Rat> rats;

    [Header("UI Objects")]
    [SerializeField] private GameObject playButton;

    //initial amount of time
    private float startingTime = 30f;

    private float remainingTime;
    private HashSet<Rat> currentRats = new HashSet<Rat>();
    private int score;
    private bool playing = false;

    
    public void StartGame()
    {
        playButton.SetActive(false);

        //hide all visible rats
        for (int i = 0; i < rats.Count; i++)
        {
            rats[i].Hide();
            rats[i].SetIndex(i);
        }
        //remove any old game state
        currentRats.Clear();

        //start with 30 seconds
        remainingTime = startingTime;
        score = 0;
        playing = true;
    }

    public void AddScore(int ratIndex)
    {
        //add to and update score
        score += 1;
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
        foreach (Rat rat in rats)
        {
            rat.StopGame();
        }
        //stop the game and show the UI
        playing = false;
        playButton.SetActive(true);
    }

    void Update()
    {
        if (playing)
        {
            //update time
            remainingTime -= Time.deltaTime;
            if(remainingTime <= 0)
            {
                remainingTime = 0;
                GameOver(0);
            }

            if (currentRats.Count <= (score / 10))
            {
                int index = Random.Range(0, rats.Count);
                if (!currentRats.Contains(rats[index]))
                {
                    currentRats.Add(rats[index]);
                    rats[index].Activate(score / 10);
                }
            }
        }
    }
}
