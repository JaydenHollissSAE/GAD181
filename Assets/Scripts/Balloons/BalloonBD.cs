using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalloonBD : MonoBehaviour
{
    public int value;
    private Vector2 moveTo;
    [SerializeField] float moveSpeed;

    public void Pop()
    {
        GameManagerBD.inst.pointCallback.Invoke(value);
        Destroy(gameObject);
    }
    private void Start()
    {
        moveTo = new Vector2(-transform.position.x, transform.position.y);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime*moveSpeed);
        if (Vector2.Distance(transform.position, moveTo) <= 1.0f) 
        {
            Destroy(gameObject);
        }
    }
}
