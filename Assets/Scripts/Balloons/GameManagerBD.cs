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

    public class GameManagerBD : MonoBehaviour
    {
        public static GameManagerBD inst;
        public PointCallback pointCallback;

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