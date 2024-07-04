using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHitManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Hit Detected");
                Destroy(hit.collider.gameObject);
                //Debug.Log(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("Hit Not Detected");
            }
        }
    }
}
