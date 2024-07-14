using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonDarts
{
    public class SpawnerBD : MonoBehaviour
    {
        public List<GameObject> balloons = new List<GameObject>();
        [SerializeField] List<Vector2> spawnPositions = new List<Vector2>();

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnBalloons());

        }

        private IEnumerator SpawnBalloons()
        {
            GameObject b = Instantiate(balloons[Random.Range(0, balloons.Count)], spawnPositions[Random.Range(0, spawnPositions.Count)], Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
            StartCoroutine(SpawnBalloons());

        }
    }
}