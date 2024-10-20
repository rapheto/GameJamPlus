using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Slider healthBar;

    public Camera cameraGame;
    public Transform target;
    public Vector3 offset;
    public Enemy enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        cameraGame = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
        healthBar.maxValue = enemyScript.maxLife;
        healthBar.value = enemyScript.currentLife;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.rotation = cameraGame.transform.rotation;
        healthBar.value = enemyScript.currentLife;
    }
}
