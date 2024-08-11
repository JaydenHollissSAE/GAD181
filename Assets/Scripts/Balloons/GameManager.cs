using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BalloonDarts
{
    [System.Serializable]
    public class PointCallback : UnityEvent<int>
    {

    }

    public class GameManager : MonoBehaviour
    {
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