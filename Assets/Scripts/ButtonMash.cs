using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMash : MonoBehaviour
{
    public float mashDelay = .5f;
    float mash;
    bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        mash = mashDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && !pressed)
        {
            pressed = true;
            mash = mashDelay;
            Debug.Log("PRESSED");
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            pressed = false;
        }
        if (mash <=0) 
        {
            Debug.Log("GAME OVER");
        }
    }
}
