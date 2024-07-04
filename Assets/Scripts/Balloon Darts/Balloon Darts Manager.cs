using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonDartsManager : MonoBehaviour
{
    public List<Vector2> rowsStarting = new List<Vector2>();
    public List<Vector2> rowsEnding = new List<Vector2>();
    public List<GameObject> balloons = new List<GameObject>();
    public GameObject balloonHolder;
    public List<float> balloonSpeed = new List<float>();
}
