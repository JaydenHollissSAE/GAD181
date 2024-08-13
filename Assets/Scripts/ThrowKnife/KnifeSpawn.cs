using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject knifeObject;

    public void SpawnKnife()
    {
        Instantiate(knifeObject, transform.position, Quaternion.identity);
    }
}
