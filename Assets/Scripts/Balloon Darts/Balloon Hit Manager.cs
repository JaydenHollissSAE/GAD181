using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonHitManager : MonoBehaviour
{
    private BalloonDartsManager balloonDartsManager;
    private BalloonPopManager balloonPopManager;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        BalloonDartsManager.current.onBalloonPop += PopBalloon;
        id = this.GetInstanceID();
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
                Debug.Log(hit);
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
        if (id == this.id)
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
