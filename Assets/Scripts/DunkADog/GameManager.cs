using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace dunkADog
{
    public class GameManager : MonoBehaviour
    {

        private int score;
        private int level;

        private bool playing = false;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartGame()
        {
            playing = true;
            level = 1;
        }

        public void Missed()
        {

        }


        public void NextLevel()
        {
            level++;
        }
    }
}
