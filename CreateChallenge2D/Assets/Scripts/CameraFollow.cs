using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 velocity;
    public Transform target;
    public float smoothSpeed = 0.125f;

    void Update ()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothSpeed);
        float posY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothSpeed);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }

}
