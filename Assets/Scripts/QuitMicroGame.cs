using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMicroGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (SceneManager.GetActiveScene().name != "MENU")
            {
                if (SceneManager.GetActiveScene().name == "GameSelect")
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
