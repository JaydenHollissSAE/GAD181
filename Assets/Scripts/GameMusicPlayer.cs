using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicPlayer : MonoBehaviour
{
    private DataStorage dataStorage;
    private AudioSource music;
    // Start is called before the first frame update
    void Awake()
    {
        dataStorage = GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>();
        music = GetComponent<AudioSource>();
        music.volume = dataStorage.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
