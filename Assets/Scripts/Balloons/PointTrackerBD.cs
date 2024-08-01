using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonDarts
{
    public class PointTrackerBD : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameManagerBD.inst.pointCallback.AddListener(UpdateUI);

        }

        // Update is called once per frame
        void UpdateUI(int points)
        {
            Debug.Log("Points here: " + points);
        }
    }
}