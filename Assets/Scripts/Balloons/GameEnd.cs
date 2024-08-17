using BalloonDarts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public GameObject endGameObject;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.inst.timeUp.AddListener(EndGame);
    }

    // Update is called once per frame
    public void EndGame()
    {

        Instantiate(endGameObject);
        int ticketsGained = Mathf.RoundToInt(GetComponent<PointTrackerBD>().totalPoints / 10);
        GameObject.FindGameObjectWithTag("AwardTickets").GetComponent<TextMeshProUGUI>().text = ticketsGained.ToString() + " Tickets Awarded";
        GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>().tickets += ticketsGained;
    }
}
