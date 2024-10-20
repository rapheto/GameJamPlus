using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float maxLife;
    public float currentLife;


    public bool inRange;
    private bool isTakingDamage;
    public Aurea aureaScript;

    public GameObject Player;
    public float speed;
    private float distance;

    public GameObject spawnXp;
    public Transform target;

    [SerializeField] private AudioSource danoEnemyAudioSource;
    [SerializeField] private AudioSource passosEnemyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        PassosEnemy();
        maxLife = 100;
        currentLife = maxLife;
        target = gameObject.GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player");
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
            currentLife -= 50;
            DanoEnemy();
        }
        if (collision.gameObject.tag == "OrbitCircle")
        {
            currentLife -= 10;
            DanoEnemy();
        }
        if (collision.gameObject.tag == "OrbitCircle2")
        {
            currentLife -= 10;
            DanoEnemy();
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
            currentLife -= aureaScript.aureaDamage;
            DanoEnemy();
        }
    }
    void Die()
    {
        if (currentLife <= 0)
        {
            
            Destroy(gameObject);
            Instantiate(spawnXp, target.position, target.rotation);
            DanoEnemy();
        }
    }
    private void DanoEnemy()
    {
        danoEnemyAudioSource.Play();
    }

    private void PassosEnemy()
    {
        passosEnemyAudioSource.Play();
    }
}
