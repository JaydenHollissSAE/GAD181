using BalloonDarts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endGame;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.inst.timeUp.AddListener(EndGame);
    }

    // Update is called once per frame
    public void EndGame()
    {
        Instantiate(endGame);
    }
}
