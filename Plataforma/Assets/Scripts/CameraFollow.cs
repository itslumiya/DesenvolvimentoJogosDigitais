using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      // arraste o jogador aqui no Inspector
    public float smoothSpeed = 0.125f;
    public Vector3 offset;        // ajuste se quiser a câmera mais à frente ou acima

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}