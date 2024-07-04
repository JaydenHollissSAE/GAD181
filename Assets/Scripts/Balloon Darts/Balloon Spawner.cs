using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonHolder;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBalloons());

    }

    private IEnumerator SpawnBalloons()
    {
        Instantiate(balloonHolder);
        yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
        StartCoroutine(SpawnBalloons());

    }

}
