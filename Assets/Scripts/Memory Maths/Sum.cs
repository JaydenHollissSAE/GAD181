using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sum : MonoBehaviour
{
    public int sumGoal;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSumGoal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateSumGoal()
    {
        sumGoal = Random.Range(10, 30);
    }
}
