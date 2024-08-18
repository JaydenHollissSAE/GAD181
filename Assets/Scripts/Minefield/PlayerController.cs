using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Milo.Minefield
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 15f;
        public Transform movePoint;

        public LayerMask whatIsMines;
        public LayerMask whatIsBarriers;

        public MineControl mineControl;
        private AudioSource step;
        private bool gameComplete;
        private AudioSource exploadSound;
        private int amountHit = 0;
        [SerializeField] private GameObject endGameObject;
        // Start is called before the first frame update
        void Start()
        {
            movePoint.parent = null;
            step = GetComponents<AudioSource>()[0];
            exploadSound = GetComponents<AudioSource>()[1];
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) < 0.1f)
            {

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, whatIsBarriers))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        step.Play();
                    }
                }

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, whatIsBarriers))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                        step.Play();
                    }
                }
            }

            Collider2D hit;
            hit = Physics2D.OverlapCircle(movePoint.position, 0.05f, whatIsMines);
            if (hit != null)
            {
                Debug.Log(hit.gameObject);
                movePoint.position = new Vector3(5.5f, -4.5f, -1);
                mineControl.DisableMine(hit);
                hit = null;
                amountHit += 1;
                exploadSound.Play();
            }

            if (!gameComplete)
            {
                if (Vector3.Distance(transform.position, new Vector3(-5.5f, 4.5f, -1f)) < 0.1f)
                {

                    gameComplete = true;
                    int ticketsGained = 20 - amountHit;
                    Instantiate(endGameObject);
                    GameObject.FindGameObjectWithTag("AwardTickets").GetComponent<TextMeshProUGUI>().text = ticketsGained.ToString() + " Tickets Awarded";
                    GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>().tickets += ticketsGained;

                }
                else if (GameObject.FindGameObjectWithTag("timer").GetComponent<Timer>().timePassed >= GameObject.FindGameObjectWithTag("timer").GetComponent<Timer>().gameTime)
                {
                    gameComplete = true;
                    Instantiate(endGameObject);
                    GameObject.FindGameObjectWithTag("AwardTickets").GetComponent<TextMeshProUGUI>().text = "0 Tickets Awarded";
                }
            }

            
        }
    }
}