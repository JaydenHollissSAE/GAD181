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
        public bool hookActive = false;
        public GameObject hookHold;
        public bool catching = false;
        public bool isLeft = false;
        public GameObject fishingRodHold;

        public static GameManager inst;
        public PointCallback pointCallback;
        public UnityEvent timeUp;

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
        }
    }
}
