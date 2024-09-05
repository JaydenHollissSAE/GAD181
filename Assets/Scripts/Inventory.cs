using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private DataStorage dataStorage;
    //private List<string> obtainedItems = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        dataStorage = GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>();
        if (dataStorage.inventory.Contains(gameObject.name))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }


        //obtainedItems = dataStorage.inventory.Split("|||||").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
