using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTime;
    private float timeToDisplay;
    private bool isRunning;
    [SerializeField] private GameObject painelJogar;


    // Start is called before the first frame update
    void Start()
    {
        timeToDisplay = 0f;
    }

    void Update()
    {
        if (isRunning)
        {
            timeToDisplay += Time.deltaTime; // Atualiza o tempo
            UpdateTimerDisplay(); // Atualiza a exibição do cronômetro
        }
    }

    public void TimerComeca()
    {
        isRunning = true;
        painelJogar.SetActive(false);
    }
    void UpdateTimerDisplay()
    {
        float minutos = Mathf.FloorToInt(timeToDisplay / 60);
        float segundos = Mathf.FloorToInt(timeToDisplay % 60);
        float milesimos = Mathf.FloorToInt((timeToDisplay - Mathf.FloorToInt(timeToDisplay)) * 1000);

        txtTime.text = string.Format("{0:00}:{1:00}:{2:000}", minutos, segundos, (int)milesimos);
    }


    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetFinalTime()
    {
        return timeToDisplay;
    }
}
