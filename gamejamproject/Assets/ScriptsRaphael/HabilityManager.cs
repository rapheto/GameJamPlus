using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityManager : MonoBehaviour
{
    public Player playerScript;
    public Gun gunScript;
    public OrbitHability habilityScript;
    public GameObject habilityPanel;

    private void Update()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gunScript = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        habilityScript = GameObject.FindGameObjectWithTag("OrbitHab").GetComponent<OrbitHability>();
    }
    public void UparArma()
    {
        if(gunScript.gunLevel < 4)
        {
            gunScript.gunLevel++;
            habilityPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }  
    }
    public void UparAurea()
    {
        if (playerScript.AureaLevel < 5)
        {
            playerScript.AureaLevel++;
            habilityPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void UparOrbit()
    {
        if (habilityScript.orbitLevel < 5)
        {
            habilityScript.orbitLevel++;
            habilityPanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
