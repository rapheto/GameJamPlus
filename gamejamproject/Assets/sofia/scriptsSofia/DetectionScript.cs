using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public bool  AwereOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer {  get; private set; }

    [SerializeField]
    private float playerAwerenessDistance;

    private Transform player;

    private void Awake()
    {
        player = FindFirstObjectByType<PlayerController>().transform;
    }

    void Update()
    {
       Vector2 enemyToPlayeVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayeVector.normalized;

        if(enemyToPlayeVector.magnitude <= playerAwerenessDistance)
        {
            AwereOfPlayer = true;
        }
        else
        {
            AwereOfPlayer = false;
        }

    }
}
