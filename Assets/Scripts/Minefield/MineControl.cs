using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineControl : MonoBehaviour
{
    SpriteRenderer mineSpriteRenderer;

    public void DisableMine(Collider2D mine)
    {
        Debug.Log("disabled " + mine);
        mine.enabled = false;
        mineSpriteRenderer = mine.GetComponent<SpriteRenderer>();

        mineSpriteRenderer.enabled = true;
        
    }
}
