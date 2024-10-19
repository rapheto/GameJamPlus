using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f; // Velocidade da bala
    private Rigidbody2D rb;

    // Start � chamado uma vez quando a bala � instanciada
    void Start()
    {
        // Obt�m o componente Rigidbody2D da bala
        rb = GetComponent<Rigidbody2D>();

        // Define a velocidade da bala de acordo com a dire��o da sua rota��o (bulletPoint)
        rb.velocity = transform.right * bulletSpeed;

        // Destroi a bala ap�s 5 segundos para evitar que fique na cena
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    // Detecta colis�es com outros objetos
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else { Destroy(gameObject, 0.3f); }
    }
}