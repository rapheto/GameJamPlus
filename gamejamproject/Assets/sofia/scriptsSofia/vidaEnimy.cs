using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnimy : MonoBehaviour
{
    public string tagDetection = "Bullet";
    public GameObject enemy;

    public GameObject spawn;
    public Transform target;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagDetection)
        {
            Destroy(enemy);
            Instantiate(spawn, target.position, target.rotation);
        }
    }
}
