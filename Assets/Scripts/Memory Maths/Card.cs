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

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        }

        private void OnMouseDown()
        {
            if(!cardSelected)
            {
                cardSelected = true;
                setup.cardsSelected.Add(cardID);

            } else
            {
                cardSelected = false;
                setup.cardsSelected.Remove(cardID);
            }
            for (int i =0;i < setup.cardsSelected.Count;i++)
            {
                Debug.Log(setup.cardsSelected[i]);
            }
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

