using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Timer timerManager;

    void Update()
    {
        // Aqui voc� pode adicionar a l�gica de controle do jogador

        // Exemplo: simular a morte do jogador
        if (Input.GetKeyDown(KeyCode.Space)) // Pressione espa�o para simular a morte
        {
            Die();
        }
    }

    void Die()
    {
        timerManager.StopTimer(); // Para o cron�metro
        float finalTime = timerManager.GetFinalTime(); // Obt�m o tempo final
        Debug.Log("Tempo final: " + finalTime); // Mostra no console

        // Aqui voc� pode adicionar l�gica para reiniciar o jogo ou ir para outra cena
        // Exemplo: SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
