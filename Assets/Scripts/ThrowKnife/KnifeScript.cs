using Milo.MemoryMath;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KnifeThrow
{
    public class KnifeScript : MonoBehaviour
    {
        [SerializeField]
        private Vector2 force;

        private bool isActive = true;

        private Rigidbody2D rb;
        private BoxCollider2D knifeCollider;
        private GameObject spawnScriptObject;
        private GameObject woodObject;
        public KnifeSpawn spawnScript;
        public WoodHealth damage;
        private Timer timer;
        [SerializeField] private GameObject timerObject;
        public TMP_Text displayText;
        public GameObject textObject;
        private AudioSource knifeThrowSound;
        private AudioSource knifeHitSound;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            knifeCollider = GetComponent<BoxCollider2D>();
            woodObject = GameObject.FindGameObjectWithTag("wood");
            spawnScriptObject = GameObject.FindGameObjectWithTag("spawn");
            spawnScript = spawnScriptObject.GetComponent<KnifeSpawn>();
            damage = woodObject.GetComponent<WoodHealth>();
            timerObject = GameObject.FindGameObjectWithTag("timer");
            timer = timerObject.GetComponent<Timer>();
            textObject = GameObject.FindGameObjectWithTag("Text");
            displayText = textObject.GetComponent<TMP_Text>();
            knifeThrowSound = GetComponents<AudioSource>()[0];
            knifeHitSound = GetComponents<AudioSource>()[1];
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && isActive)
            {
                knifeThrowSound.Play();
                rb.AddForce(force, ForceMode2D.Impulse);
                rb.gravityScale = 1;
                Debug.Log("PRESS"); //Testing
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!isActive)
                return;

            isActive = false;

            if (collision.collider.tag == "wood")
            {
                knifeHitSound.Play();
                rb.velocity = new Vector2(0, 0);
                rb.bodyType = RigidbodyType2D.Kinematic;
                this.transform.SetParent(collision.collider.transform);

                knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
                knifeCollider.size = new Vector2(knifeCollider.size.x, 0.95f);

                damage.Damage();
                //for (int i = 1;i < damage.health; i++) for testing
                spawnScript.SpawnKnife();
                damage.ticketsGained += 3;
            }
            else if (collision.collider.tag == "knife" || timer.timePassed >= 10f)
            {
                Debug.Log("GAME OVER!"); // testing
                displayText.text = "YOU LOST!";
                rb.velocity = new Vector2(rb.velocity.x, -2);
                damage.ticketsGained -= 5;
                if (damage.ticketsGained < 0) 
                {
                    damage.ticketsGained = 0;
                }
                damage.EndGame();
            }
        }
    }


}