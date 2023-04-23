using Scene;
using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(RaysViewer))]
public class SurfaceController
{
    [SerializeField] private Sphere _sphere;
    [SerializeField] private LayerMask _layerMask;

    public bool OnGround => Physics.CheckSphere(_sphere.CenterPivot.position, _sphere.Radius, _layerMask);
}
