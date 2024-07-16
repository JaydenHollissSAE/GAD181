using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milo.MemoryMath
{
    public class Card : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        }

        private void OnMouseDown()
        {
            Debug.Log("Card " + this + " clicked");
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

