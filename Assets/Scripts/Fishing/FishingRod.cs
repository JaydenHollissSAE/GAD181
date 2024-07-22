using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    private Vector2 mousePos;
    [SerializeField] GameObject fishingRod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouseWorldPos);
        fishingRod.transform.position = Vector2.MoveTowards(transform.position, new Vector2(mouseWorldPos.x, fishingRod.transform.position.y), Time.deltaTime * 20.0f);

        //mousePos = new Vector2(SceneView.currentDrawingSceneView.camera.pixelWidth-Input.mousePosition.x, SceneView.currentDrawingSceneView.camera.pixelHeight - Input.mousePosition.y);
        //Debug.Log(mousePos);
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePos.x, transform.position.y), Time.deltaTime*200.0f);
    }
}
