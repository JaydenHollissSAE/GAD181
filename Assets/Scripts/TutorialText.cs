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
        text.text = "Left click on Balloons to pop them for points.";
    }

    public void ShowFishing()
    {
        tutorial.SetActive(true);
        text.text = "Left Click to cast out a line, when a fish comes near move the rod in the given direction to catch it.";
    }
    public void ShowWhackAMouse()
    {
        tutorial.SetActive(true);
        text.text = "Left click the mice as they pop up to score points and extend your time, red mice take two clicks and clicking a cactus will mean the game is over!";
    }

    public void ShowDunkADog()
    {
        tutorial.SetActive(true);
        text.text = "Left click and hold the yarn ball and move your mouse to aim at and try to hit the moving target. When the target is hit the speed will increase, hit the target on all 5 levels to dunk the dog!";
    }
    public void ShowMineField()
    {
        tutorial.SetActive(true);
        text.text = "Use the arrow keys to navigate a minefield. Try to get to the safe side but be warned, hitting a mine sends you back to the start.";
    }

    public void ShowMemoryMaths()
    {
        tutorial.SetActive(true);
        text.text = "Memorise the cards. Once they are flipped over left click the cards that add to the number displayed on the screen before the time runs out.";
    }
    public void ShowButtonMash()
    {
        tutorial.SetActive(true);
        text.text = "Smash the spacebar to help a poor fish escape a big fish before the time runs out.";
    }

    public void ShowKnifeThrow()
    {
        tutorial.SetActive(true);
        text.text = "Thow knives at the wooden board by left clicking in an attempt to break it. Beware of hitting the other knives.";
    }
    
    public void HideTutorial()
    {
        tutorial.SetActive(false);
    }

}
