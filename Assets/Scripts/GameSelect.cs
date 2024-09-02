using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour
{

    public void LoadBalloonDarts()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadFishing()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadWhackAMouse()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadDunkADog()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadMineField()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadMemoryMaths()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadButtonMash()
    {
        SceneManager.LoadScene(8);
    }

    public void LoadKnifeThrow()
    {
        SceneManager.LoadScene(9);
    }

}
