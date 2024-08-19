using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGameSelect : MonoBehaviour
{
    private int timePassed = 0;
    private TextMeshProUGUI returnTimer;
    // Start is called before the first frame update
    void Start()
    {
        returnTimer = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        timePassed += 1;
        returnTimer.text = "Returning to Game Select in " + (5-timePassed).ToString() + " seconds.";
        if (timePassed < 5)
        {
            StartCoroutine(Countdown());
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }


}
