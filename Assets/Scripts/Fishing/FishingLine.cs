using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fishing
{
    public class FishingLine : MonoBehaviour
    {
        [SerializeField] GameObject fishingRod;
        [SerializeField] GameObject hook;
        private LineRenderer lineRenderer;
        // Start is called before the first frame update
        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            lineRenderer.SetPosition(0, new Vector2(fishingRod.transform.position.x+0.3f, fishingRod.transform.position.y+2.8f));
            lineRenderer.SetPosition(1, new Vector2(hook.transform.position.x + 0.25f, hook.transform.position.y+0.37f));
        }
    }
}