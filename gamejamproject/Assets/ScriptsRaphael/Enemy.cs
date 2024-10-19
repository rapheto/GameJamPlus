using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float vida;
    public bool inRange;
    private bool isTakingDamage;
    public Aurea aureaScript;
    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
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
}
