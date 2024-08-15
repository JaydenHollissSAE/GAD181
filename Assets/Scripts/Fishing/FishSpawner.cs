using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing
{
    public class SpawnerBD : MonoBehaviour
    {
        public GameObject fish;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < Random.Range(7, 20); i++)
            {
                GameObject f = Instantiate(fish, new Vector2(0, 0), Quaternion.identity);

            }

        }
    }
}