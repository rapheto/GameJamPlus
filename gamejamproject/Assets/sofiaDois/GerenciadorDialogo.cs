using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDialogo : MonoBehaviour
{
    [SerializeField]
    public string[] frases;
    public TextAdd TextAdd;
    void Start()
    {
        TextAdd = GetComponent<TextAdd>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickOK(TextAdd txt) { 
        txt.ChamarNovaFrase();
    }
}
