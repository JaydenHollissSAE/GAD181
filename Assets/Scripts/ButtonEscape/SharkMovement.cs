using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ButtonMash
{
    public class SharkMovement : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-2.71f, 0.04f), Time.deltaTime * 2);
        }
    }
}