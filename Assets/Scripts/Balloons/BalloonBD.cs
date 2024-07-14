using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BalloonDarts
{
    public class BalloonBD : MonoBehaviour
    {
        public int value;
        private Vector2 moveTo;
        [SerializeField] float moveSpeed;
        [SerializeField] List<Sprite> balloonStates;
        private SpriteRenderer spriteRenderer;

        public void Pop()
        {
            GameManager.inst.pointCallback.Invoke(value);
            StartCoroutine(PopAnimation());
        }
        private void Start()
        {
            moveTo = new Vector2(-transform.position.x, transform.position.y);
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, moveTo) <= 1.0f)
            {
                Destroy(gameObject);
            }
        }
        private IEnumerator PopAnimation()
        {
            spriteRenderer.sprite = balloonStates[1];
            yield return new WaitForSeconds(0.02f);
            spriteRenderer.sprite = balloonStates[2];
            yield return new WaitForSeconds(0.02f);
            spriteRenderer.sprite = balloonStates[3];
            yield return new WaitForSeconds(0.02f);
            Destroy(gameObject);
        }
    }
}