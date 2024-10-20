using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string levelDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    
    public void Jogar()
    {
        SceneManager.LoadScene(levelDoJogo);
    }

    public void AbrirOpcoes()
    { 
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }
}
