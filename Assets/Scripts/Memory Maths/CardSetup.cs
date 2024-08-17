using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Milo.MemoryMath
{
    public class CardSetup : MonoBehaviour
    {
        public GameObject[] cards = new GameObject[9];
        public SpriteRenderer[] cardRenderers = new SpriteRenderer[9];
        public TMP_Text sumText;
        public Sum sumScript;

        private Sprite[] cardSprites = new Sprite[9];

        public List<int> cardsSelected = new();

        public bool cardsFlipped = false;
        public int winState = 0; // 0: null, 1: lose, 2: win

        public Sprite backOfCard;

        private void Start()
        {
            ArrangeCards();
            DoDelayAction(5f);
            for(int i  = 0; i < cards.Length; i++) {
                cardRenderers[i] = cards[i].GetComponent<SpriteRenderer>();
                cardSprites[i] = cardRenderers[i].sprite;
            }
        }

        private void Update()
        {
            CheckSelected();
            if(winState == 0)
            {
                if (!cardsFlipped)
                {
                    sumText.text = "Memorise the cards";
                } else {
                    int awayFromSum = sumScript.sumGoal - sumScript.AddUpCards();
                    sumText.text = awayFromSum.ToString();
                }
            }
            if (winState == 1)
            {
                sumText.text = "You lost. Better luck next time!";
            }
            if(winState == 2)
            {
                sumText.text = "You won! Congratulations!";
            }
            
        }

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

        public void CheckSelected()
        {
            
        }

        public void FlipCards()
        {
            if (!cardsFlipped)
            {
                cardsFlipped = true;
                for (int i = 0; i < cards.Length; i++)
                {
                    cardRenderers[i].sprite = backOfCard;
                }
            } else
            {
                cardsFlipped = false;

                for (int i = 0; i < cards.Length; i++)
                {
                    cardRenderers[i].sprite = cardSprites[i];
                }
            }
            
        }

        void DoDelayAction(float delayTime)
        {
            StartCoroutine(DelayAction(delayTime));
        }

        IEnumerator DelayAction(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            // Debug.Log("flipping cards");
            FlipCards();
        }
    }
}