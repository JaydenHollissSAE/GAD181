using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KnifeThrow
{

    public class KnifeSpawn : MonoBehaviour
    {
        [SerializeField]
        public GameObject knifeObject;

        public void SpawnKnife()
        {
            Instantiate(knifeObject, transform.position, Quaternion.identity);
            Debug.Log("spawn"); // testing
        }
    }
}