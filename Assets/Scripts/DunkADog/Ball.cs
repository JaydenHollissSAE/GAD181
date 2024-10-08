using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dunkADog;

namespace dunkADog
{
    public class Ball : MonoBehaviour
    {
        Vector3 throwVector;
        Rigidbody2D rigidbody2d;
        LineRenderer linerenderer;

        private Vector3 startPosition;
        private static GameObject ballPrefab;

        private bool hitTarget = false;


        void Awake()
        {
            rigidbody2d = this.GetComponent<Rigidbody2D>();
            linerenderer = this.GetComponent<LineRenderer>();

            startPosition = transform.position;

            rigidbody2d.gravityScale = 0;
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        void OnMouseDown()
        {
            CalculateThrowVector();
            SetArrow();
        }
        void OnMouseDrag()
        {
            CalculateThrowVector();
            SetArrow();
        }
        void CalculateThrowVector()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Ensure Z value is 0 for 2D calculations
            Vector2 distance = mousePos - this.transform.position; //doing vector2 math to ignore the z values in the distance.
            throwVector = -distance.normalized * 100;
        }
        void SetArrow()
        {
            // Start position at the center of the ball
            Vector3 startPos = this.transform.position;
            // End position based on throwVector
            Vector3 endPos = startPos + throwVector.normalized * 1.5f; // Adjust length as needed

            linerenderer.SetPosition(0, startPos); // Set the start position
            linerenderer.SetPosition(1, endPos); // Set the end position
            linerenderer.enabled = true; // Enable the LineRenderer
        }
        void OnMouseUp()
        {
            RemoveArrow();
            Throw();
        }
        void RemoveArrow()
        {
            linerenderer.enabled = false;
        }
        public void Throw()
        {
            rigidbody2d.gravityScale = 1; // Set gravity scale back to default
            rigidbody2d.constraints = RigidbodyConstraints2D.None; // Remove constraints

            rigidbody2d.AddForce(throwVector);
            StartCoroutine(DestroyAfterDelay(3.0f)); // Start coroutine to destroy the ball after 3 seconds
        }

        private IEnumerator DestroyAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay); // Wait for the specified duration

            Destroy(gameObject); // Destroy the ball

            if (!hitTarget)
            {
                GameManager.Instance.Missed();
            }
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SpawnBall();
            }
        }
        public void HitTarget()
        {
            hitTarget = true; // Set boolean to true when the ball hits the target
        }
    }
}