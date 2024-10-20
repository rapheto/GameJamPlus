using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField] private float spawnRate = 3f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private bool canSpanw = true;
    public float valorMaximoRange = 20f;
    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (canSpanw)
        {
            float randomInterval = Random.Range(0f, valorMaximoRange);
            yield return new WaitForSeconds(randomInterval);
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
