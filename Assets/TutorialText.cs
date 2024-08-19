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
        text.text = "Test your reflexes by throwing darts to pop balloons for points.";
    }

    public void ShowFishing()
    {
        tutorial.SetActive(true);
        text.text = "Click to cast out a line to catch the wild variety fish swimming in the tank.";
    }
    public void ShowWhackAMouse()
    {
        tutorial.SetActive(true);
        text.text = "A recreation of the classic Whac-A-Mole arcade game. Click the mice as they pop up to score points and extend your time, red mice take two clicks and clicking a cactus will mean the game is over!";
    }

    public void ShowDunkADog()
    {
        tutorial.SetActive(true);
        text.text = "Click and hold the yarn ball to aim with your mouse and try to hit the moving target. When the target is hit the speed will increase, hit the target on all 5 levels to dunk the dog!";
    }
    public void ShowMineField()
    {
        tutorial.SetActive(true);
        text.text = "You are walking across a minefield, get to the safe side by using the arrow keys and look out for a mine that can reset you to your starting position.";
    }

    public void ShowMemoryMaths()
    {
        tutorial.SetActive(true);
        text.text = "Test out your memory and maths by memorising the cards before they are flipped over and select the cards that add to the number displayed on the screen before the time runs out.";
    }
    public void ShowButtonMash()
    {
        tutorial.SetActive(true);
        text.text = "Smash that spacebar to help a poor fish escape a big fish before the time runs out.";
    }

    public void ShowKnifeThrow()
    {
        tutorial.SetActive(true);
        text.text = "Test out your throwing skills by clicking the left mouse button to hit a moving wood before the time runs out. Beware of hitting the other knives.";
    }
    
    public void HideTutorial()
    {
        tutorial.SetActive(false);
    }

}
