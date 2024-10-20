using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aurea : MonoBehaviour
{
    public CircleCollider2D Collider;
    public float aureaRadius;
    public float aureaDamage;
    public Player playerScript;
    public bool aureaLevelDois;
    public bool aureaLevelTres;
    public bool aureaLevelQuatro;
    public bool aureaLevelCinco;
    public GameObject aureaRange;
    // Start is called before the first frame update
    void Start()
    {
        
        aureaLevelDois = false;
        aureaLevelTres = false;
        aureaLevelQuatro = false;
        aureaLevelCinco = false;
        aureaDamage = 10;
        aureaRadius = 3f;
        Collider = GetComponent<CircleCollider2D>();
        Collider.radius = aureaRadius;
    }

    // Update is called once per frame
    void Update()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (playerScript.AureaLevel == 2 && !aureaLevelDois)
        {
            aureaRadius *= 1.5f;
            Collider.radius = aureaRadius;
            aureaRange.transform.localScale = new Vector3(6f, 6f, 1);
            aureaLevelDois = true;
        }
        else if (playerScript.AureaLevel == 3 && !aureaLevelTres)
        {
            aureaDamage *= 2f;
            aureaLevelTres= true;
            Collider.radius = aureaRadius;
        }
        else if (playerScript.AureaLevel == 4 && !aureaLevelQuatro)
        {
            aureaRadius *= 1.5f;
            aureaRange.transform.localScale = new Vector3(9f, 9f, 1);
            Collider.radius = aureaRadius;
            aureaLevelQuatro = true;

        }
        else if (playerScript.AureaLevel == 5 && !aureaLevelCinco)
        {
            aureaRadius *= 1.5f;
            aureaDamage *= 1.5f;
            Collider.radius = aureaRadius;
            aureaLevelCinco = true;
        }
    }
}
