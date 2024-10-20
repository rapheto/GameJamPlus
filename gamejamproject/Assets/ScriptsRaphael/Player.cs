using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocidadeMovimento = 5.0f; // Velocidade de movimento, você pode ajustar isso no Inspector
    private Rigidbody rb;
    private Animator animator;


    public int AureaLevel;
    public bool aureaIsOn;
    public GameObject aurea;

    public float maxLife;
    public float currentLife;
    public Slider lifeSlider;

    
    // Start is called before the first frame update
    void Start()
    {
        lifeSlider = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
        maxLife = 100;
        currentLife = maxLife;
        lifeSlider.maxValue = maxLife;
        lifeSlider.value = currentLife;
        AureaLevel = 0;
        aureaIsOn = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        

    }
    void Update()
    {
        lifeSlider.value = currentLife;
        if (AureaLevel == 1 && aureaIsOn == false)
        {
            aurea.SetActive(true);
            aureaIsOn = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Obtém os inputs de movimento do jogador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // Calcula o vetor de movimento
        Vector3 movimento = new Vector3(moveHorizontal, moveVertical, 0.0f);

        // Normaliza o vetor de movimento para evitar movimento mais rápido na diagonal
        if (movimento.magnitude > 1.0f)
        {
            movimento.Normalize();
        }

        // Aplica a força ao Rigidbody para mover o jogador
        rb.velocity = movimento * velocidadeMovimento;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
