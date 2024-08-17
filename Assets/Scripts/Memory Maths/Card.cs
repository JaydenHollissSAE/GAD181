using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milo.MemoryMath
{
    public class Card : MonoBehaviour
    {

        public CardSetup setup;

        [SerializeField] private int cardID;
        private bool cardSelected;

        SpriteRenderer spriteRenderer;

        public GameObject selectedBoard;
        public GameObject normalBoard;
        [SerializeField] private AudioSource cardFlip;

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            cardFlip = transform.parent.gameObject.GetComponent<AudioSource>();
        }

        private void OnMouseDown()
        {
            if (!setup.cardsFlipped) { return; }
            if(!cardSelected)
            {
                cardSelected = true;
                setup.cardsSelected.Add(cardID);
                gameObject.transform.SetParent(selectedBoard.transform, false);
                cardFlip.Play();
            } else
            {
                cardSelected = false;
                setup.cardsSelected.Remove(cardID);
                gameObject.transform.SetParent(normalBoard.transform, false);
                cardFlip.Play();

            }
            //for (int i =0;i < setup.cardsSelected.Count;i++)
            //{
            //    Debug.Log(i + ": " + setup.cardsSelected[i]);
            //}
        }

        private void OnMouseOver()
        {
            spriteRenderer.color = Color.grey;
        }

        private void OnMouseExit()
        {
            spriteRenderer.color = Color.white;
        }
    }
}

