using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityManager : MonoBehaviour
{
    public Player playerScript;
    public GameObject habilityPanel;

    private void Update()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void UparArma()
    {

    }
    public void UparAurea()
    {
        playerScript.AureaLevel++;
        habilityPanel.SetActive(false);
    }
}
