using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
namespace Fishing
{
    public class Fish : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
        private Vector2 moveTo;
        [SerializeField] float waitTime;
        private bool moveBuffer;
        private SpriteRenderer spriteRenderer;
        [SerializeField] List<Sprite> fishTypes = new List<Sprite>();
        [SerializeField] GameObject hook;
        [SerializeField] GameManager gameManager;
        [SerializeField] GameObject GM;
        private float fishSize;
        // Start is called before the first frame update
        void Start()
        {
            GM = GameObject.FindGameObjectWithTag("GameManager");
            //Debug.Log(GM);
            gameManager = GM.GetComponent<GameManager>();
            //Debug.Log(gameManager);
            hook = gameManager.hookHold;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            fishSize = Random.Range(0.4f, 3f);
            moveSpeed = Random.Range(0.5f, 30f);
            //waitTime = moveSpeed * Random.Range(0.08f, 0.12f);
            //Debug.Log(Mathf.RoundToInt(100f - fishSize));
            spriteRenderer.sortingOrder = Mathf.RoundToInt(100f - fishSize);
            waitTime = Random.Range(0.5f, 1.5f);
            spriteRenderer.sprite = fishTypes[Random.Range(0, fishTypes.Count - 1)];
            transform.localScale = new Vector2(fishSize, fishSize);
            StartCoroutine(MoveFish());
        }

        // Update is called once per frame
        void Update()
        {
            //moveTo.x = moveTo.x + Random.Range(-0.003f, 0.003f);
            //moveTo.y = moveTo.y + Random.Range(-0.003f, 0.003f);
            transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * moveSpeed);
            //Debug.Log(moveTo);
            HookCheck();
        }

        private void SetMovementPos()
        {
            moveTo = new Vector2(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10));
            if (moveTo.x > transform.position.x && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else if (moveTo.x < transform.position.x && transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (moveTo.x > 8 || moveTo.x < -8)
            {
                while (moveTo.x > 8 || moveTo.x < -8)
                {
                    moveTo.x = Random.Range(transform.position.x - 10, transform.position.x + 10);
                }
                //Debug.Log("Recalculating X");
            }
            if (moveTo.y > 4.8 || moveTo.y < -4.8)
            {
                while (moveTo.y > 4.8 || moveTo.y < -4.8)
                {
                    moveTo.y = Random.Range(transform.position.y - 10, transform.position.y + 10);
                }
                //Debug.Log("Recalculating Y");
            }
        }

        private IEnumerator MoveFish()
        {
            SetMovementPos();
            //Debug.Log("Wait Started");
            yield return new WaitForSeconds(waitTime);
            //Debug.Log("I waited for you, just like you asked of me");
            StartCoroutine(MoveFish());
        }
        private void HookCheck()
        {
            if (gameManager.hookActive)
            {
                if (Vector2.Distance(transform.position, hook.transform.position) < 0.7f)
                {
                    Debug.Log("Close");
                }
                //Debug.Log("Active");
            }
        }
    }
}