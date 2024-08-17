using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodHealth : MonoBehaviour
{
    public int health = 10;

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Debug.Log("GAME Winner");
        } 
    }
}
