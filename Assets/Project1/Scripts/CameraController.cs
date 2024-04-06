using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
