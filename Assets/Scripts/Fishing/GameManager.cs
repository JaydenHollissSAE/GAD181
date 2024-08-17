using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Fishing
{
    [System.Serializable]
    public class PointCallback : UnityEvent<int>
    {

    }
    public class GameManager : MonoBehaviour
    {
        public GameObject timerObject;
        private Timer timer;
        public bool hookActive = false;
        public GameObject hookHold;
        public bool catching = false;
        public bool isLeft = false;
        public GameObject fishingRodHold;
        [SerializeField] private GameObject endGame;
        public static GameManager inst;
        public PointCallback pointCallback;
        public UnityEvent timeUp;
        private bool gameEnded = false;

        void Awake()
        {
            if (inst == null)
            {
                inst = this;
            }
            else
            {
                Destroy(this);
            }
            timer = timerObject.GetComponent<Timer>();
        }
        private void Update()
        {
            if (!gameEnded)
            {
                if (timer.timePassed >= timer.gameTime)
                {
                    gameEnded = true;
                    Instantiate(endGame);
                }
            }
        }
    }
}
