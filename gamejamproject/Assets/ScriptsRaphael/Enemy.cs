using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float vida;
    public bool inRange;
    private bool isTakingDamage;
    public Aurea aureaScript;

    public GameObject Player;
    public float speed;
    private float distance;

    public GameObject spawnXp;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player");
        vida = 100;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed *Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        aureaScript = GameObject.FindGameObjectWithTag("Aurea").GetComponent<Aurea>();
        if (inRange && !isTakingDamage)
        {
            StartCoroutine(danoAurea());
            Debug.Log("Entrou");
            isTakingDamage = true; 
        }
        else if (!inRange && isTakingDamage)
        {
            StopCoroutine(danoAurea());
            Debug.Log("Saiu");
            isTakingDamage = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aurea")
        {
            inRange = true;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            vida -= 50;
        }
        if (collision.gameObject.tag == "OrbitCircle")
        {
            vida -= 10;
        }
        if (collision.gameObject.tag == "OrbitCircle2")
        {
            vida -= 10;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aurea")
        {
            inRange = false;
        }
    }
    IEnumerator danoAurea()
    {
        while (inRange)
        {
            yield return new WaitForSeconds(1);
            vida -= aureaScript.aureaDamage;
        }
    }
    void Die()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(spawnXp, target.position, target.rotation);
        }
    }
}
