using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] List<Sprite> timerSprites = new List<Sprite>();
    private int currentSpriteId;
    public float gameTime;
    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        yield return new WaitForSeconds(1f);

        if (timePassed >= gameTime / timerSprites.Count * (currentSpriteId+1)) 
        {
            spriteRenderer.sprite = timerSprites[currentSpriteId];
            currentSpriteId += 1;
        }
        timePassed += 1;

//        yield return new WaitForSeconds(gameTime/timerSprites.Count);
        if (timePassed < gameTime)
        {
            StartCoroutine(RunTimer());
        }
    }

}
