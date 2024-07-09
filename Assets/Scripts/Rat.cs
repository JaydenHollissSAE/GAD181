using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite rat;
    [SerializeField] private Sprite ratCrossEyes;
    [SerializeField] private Sprite ratRedEyes;
    [SerializeField] private Sprite ratRedEyesHit;
    [SerializeField] private Sprite ratRedCrossEyes;

    private bool hittable = true;

    //start and end location for rat popping up and down
    private Vector2 startPosition = new Vector2(0f, -8.4f);
    private Vector2 endPosition = new Vector2(0f, 0.55f);

    //how long the mole shows for
    private float showDuration = 0.5f;
    private float duration = 1f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<spriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (hittable)
        {
            spriteRenderer.sprite = ratCrossEyes;
            //stop the animation
            StopAllCoroutines();
            StartCoroutine(QuickHide());
            
            hittable = false;
        }       
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);
        if (!hittable)
        {
            Hide();
        }
    }

    public void Hide()
    {
        transform.localPosition = startPosition;
    }


    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        //make sure rat is at start
        transform.localPosition = start;

        //showing the rat
        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            //update at max framerate
            elapsed += Time.deltaTime;
            yield return null;
        }
        //make sure rat is at end
        transform.localPosition = end;

        //wait for duration to pass
        yield return new WaitForSeconds(duration);

        //hide the rat
        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            //update at max framrate
            elapsed += Time.deltaTime;
            yield return null;
        }
        //make sure rat is at start
        transform.localPosition = start;
    }




    // Start is called before the first frame update
   private void Start()
    {
        StartCoroutine(ShowHide(startPosition, endPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
