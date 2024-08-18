using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Milo.MemoryMath
{

    public class Sum : MonoBehaviour
    {
        public CardSetup setup;

        public int sumGoal;
        [SerializeField] private GameObject endGameObject;
        private bool gameComplete = false;

        // Start is called before the first frame update
        void Start()
        {
            GenerateSumGoal();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameObject.FindGameObjectWithTag("timer").GetComponent<Timer>().timePassed >= GameObject.FindGameObjectWithTag("timer").GetComponent<Timer>().gameTime) 
            {
                if (!gameComplete)
                {
                    ConfirmSelection();
                }
            }
        }

        public void GenerateSumGoal()
        {
            sumGoal = Random.Range(10, 30);
        }

        public int AddUpCards()
        {
            int tempSum = 0;
            foreach (int number in setup.cardsSelected)
            {
                tempSum += number;
            }
            return tempSum;
        }

        public void ConfirmSelection()
        {
            gameComplete = true;
            setup.FlipCards();
            int ticketsGained = 0;
            if (AddUpCards() == sumGoal)
            {
                setup.winState = 2;
                ticketsGained = 30;
            } else
            {
                setup.winState = 1;
            }

            Instantiate(endGameObject);
            GameObject.FindGameObjectWithTag("AwardTickets").GetComponent<TextMeshProUGUI>().text = ticketsGained.ToString() + " Tickets Awarded";
            GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>().tickets += ticketsGained;
        }
    }
}
