using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milo.MemoryMath
{
    public class CardSetup : MonoBehaviour
    {
        public GameObject[] cards = new GameObject[9];

        public Card card;

        public bool cardsFlipped = false;

        private void Start()
        {
            ArrangeCards();
            DoDelayAction(5f);
        }

        // private void Update()
        // {
        //     FlipCards();
        // }

        public void ArrangeCards()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                float randomX = Random.Range(-0.35f, 0.35f);
                float randomY = Random.Range(-0.35f, 0.35f);
                float randomRot = Random.Range(-45f, 45f);
                cards[i].transform.localPosition = new Vector3(randomX, randomY, -1f);
                cards[i].transform.rotation = Quaternion.Euler(0, 0, randomRot);
            }
        }

        public void FlipCards()
        {
            if (!cardsFlipped)
            {
                return;
            }
            for (int i = 0; i < cards.Length; i++)
            {
                FlipCards();
            }
        }

        void DoDelayAction(float delayTime)
        {
            StartCoroutine(DelayAction(delayTime));
        }

        IEnumerator DelayAction(float delayTime)
        {
            //Wait for the specified delay time before continuing.
            yield return new WaitForSeconds(delayTime);

            //Do the action after the delay time has finished.
            Debug.Log("flipping cards");
            FlipCards();
            // cardsFlipped = true;
        }
    }
}