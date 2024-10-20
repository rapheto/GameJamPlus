using System.Collections;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimentação
    public GameObject objectToSpawn; // Prefab do objeto a ser gerado
    public float spawnInterval = 2f; // Intervalo de spawn
    public float objectSpeed = 10f; // Velocidade dos objetos gerados

    private SpriteRenderer spriteRenderer; // Renderer da sprite
    private Vector2 lastDirection = Vector2.right; // Direção inicial

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       // StartCoroutine(SpawnObjects());
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Captura o input horizontal e vertical
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Cria um vetor de movimento
        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed * Time.deltaTime;

        // Move o personagem
        transform.Translate(movement);

        // Atualiza a direção
        if (movement != Vector2.zero)
        {
            lastDirection = movement;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        // Inverte a sprite com base na direção
        if (lastDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (lastDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

   /* private IEnumerator SpawnObjects()
    {
        while (true) // Loop infinito
        {
            // Instancia o objeto na posição do personagem
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

            // Calcula a direção e velocidade do objeto
            Rigidbody2D spawnedRb = spawnedObject.GetComponent<Rigidbody2D>();
            if (spawnedRb != null)
            {
                spawnedRb.velocity = lastDirection.normalized * objectSpeed;
            }

            yield return new WaitForSeconds(spawnInterval); // Espera 2 segundos
        }
    }*/
}
