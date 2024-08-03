using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dunkADog;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{

    public float amplitude = 3.0f; // The maximum distance the target moves up and down
    public float frequency = 1.0f; // How fast the target moves up and down

    private Vector3 startPosition;
    private float elapsedTime;
    private GameManager gameManager;
    private bool hasBeenHit = false; // Flag to track if the target has been hit

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        startPosition = transform.position; // Store the initial position of the target
    }

    void Update()
    {
        elapsedTime += Time.deltaTime; // Increment time
        float newY = startPosition.y + Mathf.Sin(elapsedTime * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBeenHit && collision.gameObject.CompareTag("Ball"))
        {
            hasBeenHit = true; // Set flag to true to prevent multiple hits
            if (gameManager != null)
            {
                gameManager.LevelUp(); // Notify GameManager about the hit
            }
        }
    }

    public void ResetHitStatus()
    {
        hasBeenHit = false; // Reset the hit status for the target
    }
}
