using Game;
using UnityEditor;
using UnityEngine;

namespace Scene
{
    [CustomEditor(typeof(FieldOfView))]
    public class FieldOfFolderEditor : Editor
    {
        private FieldOfView _fieldOfView;

        private void OnSceneGUI()
        {
            _fieldOfView = (FieldOfView)target;

            Handles.color = Color.blue;

            Handles.DrawWireArc(
                _fieldOfView.transform.position,
                _fieldOfView.transform.up,
                _fieldOfView.transform.forward,
                -_fieldOfView.AngleHalf,
                _fieldOfView.Radius);

            Handles.DrawWireArc(
                _fieldOfView.transform.position,
                _fieldOfView.transform.up,
                _fieldOfView.transform.forward,
                _fieldOfView.AngleHalf,
                _fieldOfView.Radius);

            Handles.DrawWireArc(
                _fieldOfView.transform.position,
                _fieldOfView.transform.right,
                _fieldOfView.transform.forward,
                -_fieldOfView.AngleHalf,
                _fieldOfView.Radius);

            Handles.DrawWireArc(
                _fieldOfView.transform.position,
                _fieldOfView.transform.right,
                _fieldOfView.transform.forward,
                _fieldOfView.AngleHalf,
                _fieldOfView.Radius);

            DrawDistanceLines();

            Handles.color = Color.red;

            foreach (var target in _fieldOfView.Targets)
                Handles.DrawLine(_fieldOfView.transform.position, target.position);
        }

        private void DrawDistanceLines()
        {
            DrawDistanceLine(Vector3.up);
            DrawDistanceLine(-Vector3.up);
            DrawDistanceLine(Vector3.forward);
            DrawDistanceLine(-Vector3.forward);
        }

        private void DrawDistanceLine(Vector3 side)
        {
            Vector3 from = _fieldOfView.transform.position;
            Vector3 to = _fieldOfView.transform.position + _fieldOfView.transform.forward * _fieldOfView.Radius;

            Vector3 rotationAxis = side;

            if (side == Vector3.up)
                rotationAxis = _fieldOfView.transform.up;

            if (side == Vector3.forward)
                rotationAxis = _fieldOfView.transform.right;

            if (side == -Vector3.up)
                rotationAxis = -_fieldOfView.transform.up;

            if (side == -Vector3.forward)
                rotationAxis = -_fieldOfView.transform.right;

            Quaternion rotation = Quaternion.AngleAxis(_fieldOfView.AngleHalf, rotationAxis);
            
            to = from + rotation * (to - from);

            Handles.DrawLine(from, to);
        }
    }
}