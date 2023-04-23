using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scene
{
    public class RaysViewer : MonoBehaviour
    {
        [SerializeField] private RayViewer _forwardRay = new RayViewer(Color.blue, 3, 0.75f);
        [SerializeField] private RayViewer _normalRay = new RayViewer(Color.green, 3, 1f);
        [SerializeField] private RayViewer _errorNormalRay = new RayViewer(Color.red, 3, 1.25f);

        private List<Vector3> _errorNormals = new List<Vector3>();
        private Vector3 _normal;
        
        private void OnDrawGizmos()
        {
            Draw(_forwardRay, Project(transform.forward));
            Draw(_normalRay, _normal);

            foreach (var errorNormal in _errorNormals)
                Draw(_errorNormalRay, errorNormal);
        }

        public void SetNormal(Vector3 normal)
        {
            _normal = normal;
        }

        public void AddErrorNormal(Vector3 normal)
        {
            _errorNormals.Add(normal);
        }

        public void ClearErrorNormals()
        {
            _errorNormals.Clear();
        }

        public Vector3 Project(Vector3 forward)
        {
            return forward - Vector3.Dot(forward, _normal) * _normal;
        }

        public void Draw(RayViewer rayViewer, Vector3 direction)
        {
            Gizmos.color = rayViewer.Color;

            Vector3 relativeHeight = transform.up * rayViewer.Height;
            Vector3 start = transform.position + relativeHeight;
            Vector3 end = transform.position + direction * rayViewer.Size + relativeHeight;

            Gizmos.DrawLine(start, end);
        }
    }
}