using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitcircle : MonoBehaviour
{
    public GameObject targetObject;   // Objeto ao redor do qual o círculo irá girar
    public float orbitRadius = 3.0f;  // Distância entre o círculo e o alvo (raio da órbita)
    public float orbitSpeed = 50.0f;  // Velocidade de rotação (graus por segundo)
    public float initialAngleOffset;  // Ângulo inicial para evitar sobreposição

    private Vector3 orbitOffset;      // Deslocamento inicial para manter o círculo na posição correta

    void Start()
    {
        // Define a posição inicial do círculo com base no raio da órbita e no ângulo inicial
        if (targetObject != null)
        {
            // Converte o ângulo inicial para radianos e define o offset baseado nele
            float angleRadians = initialAngleOffset * Mathf.Deg2Rad;
            float xOffset = orbitRadius * Mathf.Cos(angleRadians);
            float yOffset = orbitRadius * Mathf.Sin(angleRadians);

            orbitOffset = new Vector3(xOffset, yOffset, 0); // Posição inicial baseada no ângulo
        }
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Calcula a rotação ao redor do alvo
            transform.position = targetObject.transform.position + orbitOffset;

            // Aplica a rotação em torno do objeto alvo
            transform.RotateAround(targetObject.transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);

            // Recalcula o deslocamento para garantir que a distância (raio) permaneça constante
            orbitOffset = transform.position - targetObject.transform.position;
            orbitOffset = orbitOffset.normalized * orbitRadius;  // Normaliza para manter o raio constante
        }
    }
}
