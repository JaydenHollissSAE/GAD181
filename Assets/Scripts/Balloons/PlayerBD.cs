using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonDarts
{
    public class PlayerBD : MonoBehaviour
    {
        //[SerializeField] GameObject dart;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Vector3 mousePos = Input.mousePosition;
                //Vector3 dartPos = Camera.current.ScreenToWorldPoint(mousePos);
                //GameObject d = Instantiate(dart, dartPos, Quaternion.identity);
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.Log(Input.mousePosition);
                //Debug.Log(dartPos);
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    hit.transform.gameObject.GetComponent<BalloonBD>().Pop();
                }
            }
        }
    }
}