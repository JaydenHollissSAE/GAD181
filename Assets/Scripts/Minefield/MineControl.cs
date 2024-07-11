using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineControl : MonoBehaviour
{
    Renderer mineRenderer;

    public void DisableMine(Collider2D mine)
    {
        Debug.Log("disabled " + mine);
        mine.enabled = false;
        mineRenderer = mine.GetComponent<Renderer>();

        mineRenderer.material.SetColor("_Color", Color.grey);
    }
}
