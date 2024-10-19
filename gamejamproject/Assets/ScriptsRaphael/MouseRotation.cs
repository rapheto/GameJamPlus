using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public float sensibilidadeMouse = 2.0f; // Sensibilidade do mouse, pode ajustar isso no Inspector

    void Update()
    {
        // Encontra a c�mera principal pela tag "MainCamera"
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        if (cameraObj != null)
        {
            // Obt�m a posi��o do mouse na tela
            Vector3 mousePos = Input.mousePosition;

            // Converte a posi��o do mouse para o espa�o do mundo usando a c�mera
            Vector3 worldPos = cameraObj.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cameraObj.transform.position.z));

            // Calcula a dire��o da rota��o do jogador em rela��o � posi��o do mouse
            Vector3 direcao = worldPos - transform.position;

            // Calcula o �ngulo em que o jogador deve rotacionar no eixo Z
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

            // Define a rota��o no eixo Z, mantendo os outros eixos inalterados
            Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, angulo);

            // Aplica a rota��o de forma suave
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, sensibilidadeMouse * Time.deltaTime);
        }
        else
        {
            Debug.LogError("Nenhuma c�mera com a tag 'MainCamera' encontrada na cena.");
        }
    }

}
