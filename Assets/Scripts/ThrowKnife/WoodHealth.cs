using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KnifeThrow { 

    public class WoodHealth : MonoBehaviour
    {
        public int health = 10;
        public TMP_Text displayText;

        public void Damage()
        {
            health--;
            if (health == 0)
            {
                Debug.Log("GAME Winner"); // testing
                displayText.text = "YOU WON!";
            } 
        }
    }
}