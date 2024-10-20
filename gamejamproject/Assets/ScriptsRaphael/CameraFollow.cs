using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Refer�ncia ao transform do jogador
    public Transform player;

    // Dist�ncia (offset) entre a c�mera e o jogador
    public Vector3 offset;

    // Velocidade de suaviza��o do movimento da c�mera
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Posi��o desejada da c�mera (posi��o do jogador + offset)
        Vector3 desiredPosition = player.position + offset;

        // Suaviza a transi��o da c�mera para a posi��o desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posi��o da c�mera
        transform.position = smoothedPosition;
    }
}
