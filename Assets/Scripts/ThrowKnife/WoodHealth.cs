using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KnifeThrow { 

    public class WoodHealth : MonoBehaviour
    {
        public int health = 10;
        public TMP_Text displayText;
        [SerializeField] private GameObject endGameObject;
        public int ticketsGained = 0;


        public void Damage()
        {
            health--;
            if (health == 0)
            {
                Debug.Log("GAME Winner"); // testing
                displayText.text = "YOU WON!";
                EndGame();
            } 
        }
        public void EndGame()
        {
            Instantiate(endGameObject);
            GameObject.FindGameObjectWithTag("AwardTickets").GetComponent<TextMeshProUGUI>().text = ticketsGained + " Tickets Awarded";
            GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>().tickets += ticketsGained;

        }
    }
}