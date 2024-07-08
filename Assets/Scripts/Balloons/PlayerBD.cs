using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBD : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(r, out hit))
            {
                hit.transform.gameObject.GetComponent<BalloonBD>().Pop();
            }
        }
    }
}
