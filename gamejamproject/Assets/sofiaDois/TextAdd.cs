using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextAdd : MonoBehaviour
{
    public string Newtext;
    public int count = 0;
    private int countLetras;
    public GerenciadorDialogo gerenciador;
    public TMP_Text texto;
    public TMP_Text textButtom;
    public GameObject Painel;
    void Start()
    {
        count = 0;
        texto = GetComponent<TMP_Text>();
        textButtom = GetComponent<TMP_Text>();
    }

    public void ChamarNovaFrase()
    {
        if (count < gerenciador.frases.Length){
        Newtext = gerenciador.frases[count];
        countLetras = 0;
        texto.text = ""; // Limpa o texto anterior
        StartCoroutine(AdicionarLetras());
        count++;
        }
        else {
                Painel.SetActive(false);
         
        }

    }

    private IEnumerator AdicionarLetras()
    {
        while (countLetras < Newtext.Length)
        {
            texto.text += Newtext[countLetras]; // Adiciona a letra
            countLetras++;
            yield return new WaitForSeconds(0.02f); // Espera 0.5 segundos antes de adicionar a próxima
        }
        
    }
}
