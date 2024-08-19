using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("TutorialText").GetComponent<TextMeshProUGUI>();
        tutorial.SetActive(false);
    }

    // Update is called once per frame
    public void ShowBalloonDarts()
    {
        tutorial.SetActive(true);
        text.text = "Balloon Darts Text Here";
    }

    public void ShowFishing()
    {
        tutorial.SetActive(true);
        text.text = "Fishing Text Here";
    }
    public void ShowWhackAMouse()
    {
        tutorial.SetActive(true);
        text.text = "Whack-A-Mouse Text Here";
    }

    public void ShowDunkADog()
    {
        tutorial.SetActive(true);
        text.text = "Dunk-A-Dog Text Here";
    }
    public void ShowMineField()
    {
        tutorial.SetActive(true);
        text.text = "Minefield Text Here";
    }

    public void ShowMemoryMaths()
    {
        tutorial.SetActive(true);
        text.text = "Memory Maths Text Here";
    }
    public void ShowButtonMash()
    {
        tutorial.SetActive(true);
        text.text = "Button Escape Text Here";
    }

    public void ShowKnifeThrow()
    {
        tutorial.SetActive(true);
        text.text = "Knife Throw Text Here";
    }
    
    public void HideTutorial()
    {
        tutorial.SetActive(false);
    }

}
