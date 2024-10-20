using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitcircle2 : MonoBehaviour
{
    public GameObject targetObject;   // Objeto ao redor do qual o c�rculo ir� girar
    public float orbitRadius = -3.0f;  // Dist�ncia entre o c�rculo e o alvo (raio da �rbita)
    public float orbitSpeed = 50.0f;  // Velocidade de rota��o (graus por segundo)

    private Vector3 orbitOffset;      // Deslocamento inicial para manter o c�rculo na posi��o correta

    void Start()
    {
        // Define a posi��o inicial do c�rculo com base no raio da �rbita
        if (targetObject != null)
        {
            orbitOffset = new Vector3(orbitRadius, 0, 0);
        }
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Calcula a rota��o ao redor do alvo
            transform.position = targetObject.transform.position + orbitOffset;

            // Aplica a rota��o em torno do objeto alvo
            transform.RotateAround(targetObject.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);

            // Recalcula o deslocamento para garantir que a dist�ncia (raio) permane�a constante
            orbitOffset = transform.position - targetObject.transform.position;
            orbitOffset = orbitOffset.normalized * orbitRadius;  // Normaliza para manter o raio constante
        }
    }
}
