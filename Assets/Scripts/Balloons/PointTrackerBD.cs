using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BalloonDarts
{
    public class PointTrackerBD : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI pointsTxt;
        [SerializeField] GameObject pointsTracker;
        private int totalPoints;
        // Start is called before the first frame update
        void Start()
        {
            GameManager.inst.pointCallback.AddListener(UpdateUI);
            //pointsTxt = pointsTracker.GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void UpdateUI(int points)
        {
            //Debug.Log("Points here: " + points);
            totalPoints += points;
            pointsTxt.text = "Points: "+totalPoints.ToString();
        }
    }
}