using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Referência ao transform do jogador
    public Transform player;

    // Distância (offset) entre a câmera e o jogador
    public Vector3 offset;

    // Velocidade de suavização do movimento da câmera
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Posição desejada da câmera (posição do jogador + offset)
        Vector3 desiredPosition = player.position + offset;

        // Suaviza a transição da câmera para a posição desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }
}
