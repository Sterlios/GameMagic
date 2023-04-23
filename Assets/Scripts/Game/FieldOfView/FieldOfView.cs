using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FieldOfView : MonoBehaviour
    {
        private readonly float _angleDevider = 2;

        [Range(10, 20)]
        [SerializeField] private float _radius = 10;
        [Range(30, 120)]
        [SerializeField] private float _angle = 30;
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private LayerMask _obstacleLayer;

        private WaitForSeconds _delay = new WaitForSeconds(0.5f);
        private Coroutine _findJob;

        public float Radius => _radius;
        public float Angle => _angle;
        public float AngleHalf => _angle / _angleDevider;
        public List<Transform> Targets { get; private set; } = new List<Transform>();

        private void OnEnable()
        {
            _findJob = StartCoroutine(FindTargets());
        }

        private void OnDisable()
        {
            StopCoroutine(_findJob);
        }

        private IEnumerator FindTargets()
        {
            while (isActiveAndEnabled)
            {
                FindVisibleTargets();

                yield return _delay;
            }
        }

        private void FindVisibleTargets()
        {
            Targets.Clear();

            Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, Radius, _targetLayer);

            foreach (var targetInViewRadius in targetsInViewRadius)
            {
                Transform target = targetInViewRadius.transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < AngleHalf)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleLayer))
                        Targets.Add(target);
                }
            }
        }
    }
}
