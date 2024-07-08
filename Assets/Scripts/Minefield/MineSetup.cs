using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSetup : MonoBehaviour
{
    public GameObject minePrefab;
    public GameObject minefieldParent;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpMines()
    {
        for (int i = 0; i < 10; i++)
        {
            float xPos = Mathf.Round(Random.Range(-5f, 4f)) + 0.5f;
            float yPos = Mathf.Round(Random.Range(-5f, 4f)) + 0.5f;

            GameObject newMine = Instantiate(minePrefab, minefieldParent.transform);
            newMine.transform.position = new Vector3(xPos, yPos, 0);
        }
    }
}
