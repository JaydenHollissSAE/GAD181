using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHitManager : MonoBehaviour
{
    private BalloonDartsManager balloonDartsManager;
    private BalloonPopManager balloonPopManager;
    private int id;
    // Start is called before the first frame update
    void Start()
    {
        BalloonDartsManager.current.onBalloonPop += PopBalloon;
        this.id = (int)Random.Range(0, 10000009462);
        Debug.Log(this.id);
        //Debug.Log(this.id);
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
                //Debug.Log(hit);
                id = hit.collider.GetInstanceID();
                //Debug.Log("Child id: "+this.transform.GetChild(0).GetInstanceID());
                Debug.Log("Hit id: "+id);
                //Debug.Log("This id: " + this.GetInstanceID());
                BalloonDartsManager.current.balloonPop(id);
                //balloonPopManager.PopBalloon();
                //Debug.Log("Hit Detected");
                //Debug.Log(this.name);
                //Destroy(hit.collider.gameObject);
                //Debug.Log(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("Hit Not Detected");
            }
        }
    }


    private void PopBalloon(int id)
    {
        //Debug.Log(id);
        if (id == this.GetInstanceID())
        {
            //Debug.Log(id);
            //Debug.Log(this.id);
            //Debug.Log(BalloonDartsManager.current.balloonPop());
            //BalloonDartsManager.current.onBalloonPop -= PopBalloon;
            //Debug.Log("Hit Detected");
            //Debug.Log(gameObject.name);
            Destroy(this.gameObject);
        }
    }

}
