using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tickets : MonoBehaviour
{
    [SerializeField] private GameObject dataStorageObject;
    private DataStorage dataStorage;
    private TextMeshProUGUI ticketAmount;
    // Start is called before the first frame update
    void Start()
    {
        ticketAmount = GetComponent<TextMeshProUGUI>();
        dataStorageObject = GameObject.FindGameObjectWithTag("DataStorage");
        dataStorage = dataStorageObject.GetComponent<DataStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ticketAmount.text != dataStorage.tickets.ToString())
        {
            ticketAmount.text = dataStorage.tickets.ToString();
        }
    }
}
