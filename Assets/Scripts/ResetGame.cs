using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    private GameObject dataStorage;
    // Start is called before the first frame update
    void Start()
    {
        dataStorage = GameObject.FindGameObjectWithTag("DataStorage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.T)) 
        {
            Destroy(dataStorage);
            SceneManager.LoadScene(0);
        }
    }
}
