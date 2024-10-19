using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Timer timerManager;

    void Update()
    {
        // Aqui você pode adicionar a lógica de controle do jogador

        // Exemplo: simular a morte do jogador
        if (Input.GetKeyDown(KeyCode.Space)) // Pressione espaço para simular a morte
        {
            Die();
        }
    }

    void Die()
    {
        timerManager.StopTimer(); // Para o cronômetro
        float finalTime = timerManager.GetFinalTime(); // Obtém o tempo final
        Debug.Log("Tempo final: " + finalTime); // Mostra no console

        // Aqui você pode adicionar lógica para reiniciar o jogo ou ir para outra cena
        // Exemplo: SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
