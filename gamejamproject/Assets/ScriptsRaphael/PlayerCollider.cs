using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public float xpAtual;
    public float xpPontuacao;
    public float levelAtual;
    public bool levelUp;

    public GameObject habilidadesPanel;
    public Player scriptPlayer;

    [SerializeField] private AudioSource xpAudioSource;
    [SerializeField] private AudioSource danoPlayerAudioSource;
    void Start()
    {
        scriptPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        habilidadesPanel.SetActive(false);
        xpPontuacao = 5;
        xpAtual = 0;
        levelAtual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LevelUpar();
    }
    void LevelUpar()
    {
        if (xpAtual >= 15)
        {
            xpAtual = 0;
            levelAtual++;
            levelUp = true;
        }
        if (levelUp) { 
            habilidadesPanel.SetActive (true);
            Time.timeScale = 0;
            levelUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Xp")
        {
            xpAtual += xpPontuacao;
            Conquista();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            scriptPlayer.currentLife -= 10;
            DanoPlayer();
        }
    }

    private void Conquista()
    {
        xpAudioSource.Play();
    }
    private void DanoPlayer()
    {
        danoPlayerAudioSource.Play();
    }

}
