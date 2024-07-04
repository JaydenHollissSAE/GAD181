using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BalloonManager : MonoBehaviour
{
    private BalloonDartsManager balloonDartsManagerScript;
    private GameObject balloonDartsManager;
    private GameObject attachedBalloon;
    private float currentPosition;
    private Vector2 endPoint;
    private Vector2 startPoint;
    private int row;
    private float speed;
    private int balloonId;

    // Start is called before the first frame update
    void Start()
    {

        balloonDartsManager = GameObject.FindGameObjectWithTag("Darts Manager");
        balloonDartsManagerScript = balloonDartsManager.GetComponent<BalloonDartsManager>();

        row = Random.Range(0, balloonDartsManagerScript.rowsStarting.Count);

        startPoint = balloonDartsManagerScript.rowsStarting[row];
        endPoint = balloonDartsManagerScript.rowsEnding[row];
        //Debug.Log(row);
        //Debug.Log(endPoint);
        //Debug.Log(startPoint);

        balloonId = Random.Range(0, balloonDartsManagerScript.balloons.Count);

        attachedBalloon = Instantiate(balloonDartsManagerScript.balloons[balloonId]);
        speed = balloonDartsManagerScript.balloonSpeed[balloonId];
        //Debug.Log(attachedBalloon);

        attachedBalloon.transform.parent = transform;
        transform.position = startPoint;
        
        //Debug.Log(Vector2.MoveTowards(transform.position, endPoint, Time.deltaTime * 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPoint, Time.deltaTime * speed);
        currentPosition = Vector2.Distance(transform.position, endPoint);
        //Debug.Log(currentPosition);
        //Debug.Log(transform.position);
        if (currentPosition <= 1.0f)
        {
            //BalloonSpawnerScript.SpawnBalloon();
            Destroy(this.gameObject);
        }

    }
}
