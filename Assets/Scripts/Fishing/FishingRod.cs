using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fishing
{
    public class FishingRod : MonoBehaviour
    {
        private Vector2 mousePos;
        [SerializeField] Camera cam;
        [SerializeField] GameObject hook;
        [SerializeField] GameObject GM;
        private GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            hook.SetActive(false);
            gameManager = GM.GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!gameManager.hookActive)
                    {
                        hook.transform.position = hit.point;
                        gameManager.hookActive = true;
                        hook.SetActive(true);
                    }
                    else
                    {
                        hook.SetActive(false);
                        gameManager.hookActive = false;
                    }
                }

                Vector2 moveTo = new Vector2(hit.point.x, gameObject.transform.position.y);
                if (moveTo.x < -8)
                {
                    moveTo.x = -8;
                }
                else if (moveTo.x > 8)
                {
                    moveTo.x = 8;
                }
                //Debug.Log(moveTo);
                gameObject.transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * 11.0f);
                //Debug.Log("Ray Hit");
            }



            //mousePos = new Vector2(SceneView.currentDrawingSceneView.camera.pixelWidth-Input.mousePosition.x, SceneView.currentDrawingSceneView.camera.pixelHeight - Input.mousePosition.y);
            //Debug.Log(mousePos);
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePos.x, transform.position.y), Time.deltaTime*200.0f);
        }
    }
}
