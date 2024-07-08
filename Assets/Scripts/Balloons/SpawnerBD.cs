using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBD : MonoBehaviour
{
    public List<GameObject> balloons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject b = Instantiate(balloons[Random.Range(0, balloons.Count)]);
    }
}
