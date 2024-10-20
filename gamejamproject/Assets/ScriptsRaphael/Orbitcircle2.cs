using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitcircle2 : MonoBehaviour
{
    public GameObject targetObject;   // Objeto ao redor do qual o círculo irá girar
    public float orbitRadius = -3.0f;  // Distância entre o círculo e o alvo (raio da órbita)
    public float orbitSpeed = 50.0f;  // Velocidade de rotação (graus por segundo)

    private Vector3 orbitOffset;      // Deslocamento inicial para manter o círculo na posição correta

    void Start()
    {
        // Define a posição inicial do círculo com base no raio da órbita
        if (targetObject != null)
        {
            orbitOffset = new Vector3(orbitRadius, 0, 0);
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
