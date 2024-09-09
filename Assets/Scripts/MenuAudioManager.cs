using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    public static MenuAudioManager instanceAudio;
    // Start is called before the first frame update
    void Awake()
    {
        if (instanceAudio == null)
        {
            instanceAudio = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MENU" && SceneManager.GetActiveScene().name != "GameSelect" && SceneManager.GetActiveScene().name != "Inventory" && SceneManager.GetActiveScene().name != "Shop")
        {
            Destroy(gameObject);
        }

    }
}
