using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBD : MonoBehaviour
{
    public int value;

    public void Pop()
    {
        GameManagerBD.inst.pointCallback.Invoke(value);
    }
}
