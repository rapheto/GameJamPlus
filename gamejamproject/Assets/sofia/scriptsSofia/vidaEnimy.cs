using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnimy : MonoBehaviour
{
    public string tagDetection = "Bullet";
    public GameObject enemy;

    public GameObject spawnXp;
    public Transform target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagDetection)
        {
            Destroy(enemy);
            Instantiate(spawnXp, target.position, target.rotation);
        }
    }
}
