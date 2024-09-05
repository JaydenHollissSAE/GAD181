using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseItem : MonoBehaviour
{
    private DataStorage dataStorage;

    // Start is called before the first frame update
    void Start()
    {
        dataStorage = GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>();
        if (dataStorage.inventory.Contains(gameObject.name))
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Purchase()
    {
        if (dataStorage.inventory != "")
        {
            dataStorage.inventory += "|||||" + gameObject.name;
        }
        else
        {
            dataStorage.inventory += gameObject.name;
        }
        gameObject.SetActive(false);
    }
}
