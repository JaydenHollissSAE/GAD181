using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    private Vector2 mousePos;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector2 moveTo = new Vector2(hit.point.x, gameObject.transform.position.y);
            Debug.Log(moveTo);
            gameObject.transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * 20.0f);
            Debug.Log("Ray Hit");
        }
        else
        {
            Debug.Log("Ray not Hit");
        }

        

        //mousePos = new Vector2(SceneView.currentDrawingSceneView.camera.pixelWidth-Input.mousePosition.x, SceneView.currentDrawingSceneView.camera.pixelHeight - Input.mousePosition.y);
        //Debug.Log(mousePos);
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePos.x, transform.position.y), Time.deltaTime*200.0f);
    }
}
