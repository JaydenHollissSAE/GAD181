using BalloonDarts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Image image;
    [SerializeField] List<Sprite> timerSprites = new List<Sprite>();
    private int currentSpriteId;
    public float gameTime;
    private float timePassed;
    [SerializeField] GameObject timerSprite;
    [SerializeField] TextMeshProUGUI timerText;
    private float timeCalc;

    // Start is called before the first frame update
    void Start()
    {
        image = timerSprite.GetComponent<Image>();
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        yield return new WaitForSeconds(1f);
        timeCalc = gameTime / timerSprites.Count * (currentSpriteId + 1);
        //Debug.Log(timeCalc);
        //Debug.Log(timeCalc - (timeCalc / (currentSpriteId + 1)));
        if (timePassed >= timeCalc - (timeCalc / (currentSpriteId+1))) 
        {
            image.sprite = timerSprites[currentSpriteId];
            currentSpriteId += 1;
        }
        timePassed += 1;
        timerText.text = (gameTime - timePassed).ToString();

//        yield return new WaitForSeconds(gameTime/timerSprites.Count);
        if (timePassed < gameTime)
        {
            StartCoroutine(RunTimer());
        }
        else
        {
            GameManager.inst.timeUp.Invoke();
        }
    }

}
