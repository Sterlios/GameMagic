using System;
using UnityEngine;

public class Viewer
{
    private Camera _camera;

    public Viewer()
    {
        _camera = Camera.main;
    }

    public Vector3 GetDirectionToWorld(Vector3 direction)
    {
        Vector3 cameraForward = GetNormalizedCameraDirection(Vector3.forward);
        Vector3 cameraRight = GetNormalizedCameraDirection(Vector3.right);

        Vector3 newDirection = (direction.x * cameraRight + direction.z * cameraForward).normalized;
        newDirection.y = 0;

        return newDirection;
    }

    private Vector3 GetNormalizedCameraDirection(Vector3 direction)
    {
        Vector3 cameraDirection = _camera.transform.TransformDirection(direction);
        cameraDirection.y = 0f;

        return cameraDirection.normalized;
    }
}