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

    private void SetMovementPos()
    {
        moveTo = new Vector2(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10));
        if (moveTo.x > 9.5 || moveTo.x < -9.5)
        {
            while (moveTo.x > 9.5 || moveTo.x < -9.5)
            {
                moveTo.x = Random.Range(transform.position.x - 10, transform.position.x + 10);
            }
            Debug.Log("Recalculating X");
        }
        if (moveTo.y > 4.8 || moveTo.y < -4.8)
        {
            while (moveTo.y > 4.8 || moveTo.y < -4.8)
            {
                moveTo.y = Random.Range(transform.position.y - 10, transform.position.y + 10);
            }
            Debug.Log("Recalculating Y");
        }
    }

    private IEnumerator MoveFish()
    {
        SetMovementPos();
        Debug.Log("Wait Started");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("I waited for you, just like you asked of me");
        StartCoroutine(MoveFish());
    }
}
