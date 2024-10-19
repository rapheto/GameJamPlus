using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public float _speed;

    [SerializeField]
    public float _rotationpeed;

    private Rigidbody2D rigidibody;

    private  DetectionScript playerawernessController;

    private Vector2 targetDirection;

    // Start is called before the first frame update
    void Awake()
    {
        rigidibody = GetComponent<Rigidbody2D>();
        playerawernessController = GetComponent<DetectionScript>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTraget();
        SetVelocity();
    }
    private void UpdateTargetDirection()
    {
        if (playerawernessController.AwereOfPlayer)
        {
            targetDirection = playerawernessController.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTraget()
    {
        if(targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation,targetRotation, _rotationpeed * Time.deltaTime);

        rigidibody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if(targetDirection != Vector2.zero) {
            rigidibody.velocity = Vector2.zero;
        }
        else
        {
            rigidibody.velocity = transform.up * _speed;
        }
    }
}

