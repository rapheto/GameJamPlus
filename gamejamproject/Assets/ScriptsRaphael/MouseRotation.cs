using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public float sensibilidadeMouse = 2.0f; // Sensibilidade do mouse, pode ajustar isso no Inspector

    void Update()
    {
        // Encontra a câmera principal pela tag "MainCamera"
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        if (cameraObj != null)
        {
            // Obtém a posição do mouse na tela
            Vector3 mousePos = Input.mousePosition;

            // Converte a posição do mouse para o espaço do mundo usando a câmera
            Vector3 worldPos = cameraObj.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cameraObj.transform.position.z));

            // Calcula a direção da rotação do jogador em relação à posição do mouse
            Vector3 direcao = worldPos - transform.position;

            // Calcula o ângulo em que o jogador deve rotacionar no eixo Z
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

            // Define a rotação no eixo Z, mantendo os outros eixos inalterados
            Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, angulo);

            // Aplica a rotação de forma suave
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, sensibilidadeMouse * Time.deltaTime);
        }
        else
        {
            Debug.LogError("Nenhuma câmera com a tag 'MainCamera' encontrada na cena.");
        }
    }

}
