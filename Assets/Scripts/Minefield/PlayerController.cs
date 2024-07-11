using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Transform movePoint;

    public LayerMask whatIsMines;

    public MineControl mineControl;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) < 0.1f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

            }
        }

        Collider2D hit;
        hit = Physics2D.OverlapCircle(movePoint.position, 0.05f, whatIsMines);
        if(hit != null)
        {
            Debug.Log(hit.gameObject);
            movePoint.position = new Vector3(4.5f, -4.5f, -1);
            mineControl.DisableMine(hit);
            hit = null;
        }
    }
}
