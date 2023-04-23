using System;
using UnityEngine;

[Serializable]
public struct Sphere
{
    [SerializeField] private Transform _centerPivot;
    [SerializeField] private float _radius;

    public Transform CenterPivot => _centerPivot;
    public float Radius => _radius;
}
