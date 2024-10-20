using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SomManager : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource fundoSom;
    [SerializeField] private AudioSource fundoSom2;
    [SerializeField] private AudioSource fundoSom3;
    [SerializeField] private AudioSource fundoSom4;
    [SerializeField] private AudioSource fundoSom5;
    [SerializeField] private AudioSource fundoSom6;
    [SerializeField] private AudioSource fundoSom7;
    [SerializeField] private AudioSource fundoSom8;


    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image muteImage;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        fundoSom.enabled = estadoSom;
        if (estadoSom)
        {
            muteImage.sprite = somLigadoSprite;
        }
        else
        {
            muteImage.sprite = somDesligadoSprite;
        }
    }
    public void VolumeMusical(float value)
    {
        Debug.Log("Funcionouuu");
        fundoSom.volume = value;
        fundoSom2.volume = value;
        fundoSom3.volume = value;   
        fundoSom4.volume = value;   
        fundoSom5.volume = value;
        fundoSom6.volume = value;
        fundoSom7.volume = value;
        fundoSom8.volume = value;
    }
}
