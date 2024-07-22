using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector2 moveTo;
    [SerializeField] float waitTime;
    private bool moveBuffer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveFish());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * moveSpeed);
        Debug.Log(moveTo);
    }



    private IEnumerator MoveFish()
    {
        moveTo = new Vector2(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10));
        Debug.Log("Wait Started");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("I waited for you, just like you asked of me");
        StartCoroutine(MoveFish());
    }
}
