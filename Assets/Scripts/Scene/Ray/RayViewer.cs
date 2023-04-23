using System;
using UnityEngine;

namespace Scene
{
    [Serializable]
    public struct RayViewer
    {
        [SerializeField] private Color _color;
        [SerializeField] private float _size;
        [SerializeField] private float _height;

        public RayViewer(Color color, float size, float height)
        {
            _color = color;
            _size = size;
            _height = height;
        }

        public Color Color => _color;
        public float Size => _size;
        public float Height => _height;
    }
}
