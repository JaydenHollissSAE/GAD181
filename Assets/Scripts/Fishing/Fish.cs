using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Vector2 moveTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTo = new Vector2(Random.Range(transform.position.x - 3, transform.position.x + 3), Random.Range(transform.position.y - 3, transform.position.y + 3));
        transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * moveSpeed);
        Debug.Log(moveTo);
    }
}
