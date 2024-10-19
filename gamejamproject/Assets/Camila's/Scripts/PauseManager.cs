using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private string levelDoJogo;
    [SerializeField] private GameObject painelInicial;
    [SerializeField] private GameObject painelPause;
    [SerializeField] private GameObject painelSaida;
    [SerializeField] private GameObject painelVoltaMenu;

    public void TrocarDeCena()
    {
        SceneManager.LoadScene(levelDoJogo);
    }

    public void AbrirPause()
    {
        painelInicial.SetActive(false);
        painelPause.SetActive(true);
        Time.timeScale = 0f;

    }

    public void FecharPause()
    {
        painelInicial.SetActive(true);
        painelPause.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void AbrirSaida()
    {
        painelPause.SetActive(false);
        painelSaida.SetActive(true);
    }
    public void FecharSaida()
    {
        painelPause.SetActive(true);
        painelSaida.SetActive(false);
    }

    public void AbrirVoltaMenu()
    {
        painelVoltaMenu.SetActive(true);
        painelPause.SetActive(false);
    }
    public void FecharVoltaMenu()
    {
        painelVoltaMenu.SetActive(false);
        painelPause.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
