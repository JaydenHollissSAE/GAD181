using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    public static DataStorage instance;
    public int tickets = 0;
    public float volume = 1f;
    private int ticketsOld = 0;
    private float volumeOld = 1f;
    public string inventory = "";

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("Volume"))
        {
            volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            volume = 1f;
        }

        if (PlayerPrefs.HasKey("Tickets"))
        {
            tickets = PlayerPrefs.GetInt("Tickets");
        }

        if (PlayerPrefs.HasKey("Inventory"))
        {
            inventory = PlayerPrefs.GetString("Inventory");
        }
    }
    private void Update()
    {
        if (tickets != ticketsOld)
        {
            PlayerPrefs.SetInt("Tickets", tickets);
            ticketsOld = tickets;
            PlayerPrefs.Save();
        }
        if (volume != volumeOld)
        {
            PlayerPrefs.SetFloat("Volume", volume);
            volumeOld = volume;
            PlayerPrefs.Save();
        }
    }
}
