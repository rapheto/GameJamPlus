using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitcircle : MonoBehaviour
{
    public GameObject targetObject;   // Objeto ao redor do qual o c�rculo ir� girar
    public float orbitRadius = 3.0f;  // Dist�ncia entre o c�rculo e o alvo (raio da �rbita)
    public float orbitSpeed = 50.0f;  // Velocidade de rota��o (graus por segundo)
    public float initialAngleOffset;  // �ngulo inicial para evitar sobreposi��o

    private Vector3 orbitOffset;      // Deslocamento inicial para manter o c�rculo na posi��o correta

    void Start()
    {
        // Define a posi��o inicial do c�rculo com base no raio da �rbita e no �ngulo inicial
        if (targetObject != null)
        {
            // Converte o �ngulo inicial para radianos e define o offset baseado nele
            float angleRadians = initialAngleOffset * Mathf.Deg2Rad;
            float xOffset = orbitRadius * Mathf.Cos(angleRadians);
            float yOffset = orbitRadius * Mathf.Sin(angleRadians);

            orbitOffset = new Vector3(xOffset, yOffset, 0); // Posi��o inicial baseada no �ngulo
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
