using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ButtonMash
{
    public class ButtonMash : MonoBehaviour
    {
        public float mashDelay = .5f;
        float mash;
        bool pressed;
        private Timer timer;
        [SerializeField] private GameObject timerObject;
        public TMP_Text displayText;
        [SerializeField] private GameObject textObject;
        void Start()
        {
            timer = timerObject.GetComponent<Timer>();
            displayText = textObject.GetComponent<TMP_Text>();
            mash = mashDelay;
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(mash);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(3.61f, 0.13f), Time.deltaTime * 2);
            if (Input.GetKeyUp(KeyCode.Space) && !pressed)
            {
                pressed = true;
                mash += mashDelay;
                Debug.Log("PRESSED"); //Testing!
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                pressed = false;
            }
            if (timer.timePassed >= 10f)
            {
                if (mash >= 15f)
                {
                    displayText.text = "YOU WON!";
                }
                else
                {
                    displayText.text = "YOU LOST!";
                }
            }

        }
    }
}