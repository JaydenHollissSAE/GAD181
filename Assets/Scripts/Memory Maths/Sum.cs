using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milo.MemoryMath
{

    public class Sum : MonoBehaviour
    {
        public CardSetup setup;

        public int sumGoal;
        // Start is called before the first frame update
        void Start()
        {
            GenerateSumGoal();
        }

        // Update is called once per frame
        void Update()
        {

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
            setup.FlipCards();
            if (AddUpCards() == sumGoal)
            {
                setup.winState = 2;
            } else
            {
                setup.winState = 1;
            }
        }
    }
}
