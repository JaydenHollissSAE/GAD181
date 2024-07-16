using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSetup : MonoBehaviour
{
    public GameObject[] cards = new GameObject[9];

    private void Start()
    {
        ArrangeCards();
    }

    public void ArrangeCards()
    {
        for(int i = 0; i < cards.Length; i++)
        {
            float randomX = Random.Range(-0.35f, 0.35f);
            float randomY = Random.Range(-0.35f, 0.35f);
            float randomRot = Random.Range(-45f, 45f);
            cards[i].transform.localPosition = new Vector3(randomX, randomY, -1f);
            cards[i].transform.rotation = Quaternion.Euler(0,0,randomRot);
        }
    }

    public void FlipCards ()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            
        }
    }
}
