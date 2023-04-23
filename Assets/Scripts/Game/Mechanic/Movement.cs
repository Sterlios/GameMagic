using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanic
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _speedMultiply;

        private CharacterController _characterController;

        public void Initialize(CharacterController characterController)
        {
            _characterController = characterController;
        }

        public void MoveDirection(Vector3 direction, bool isRun)
        {
            float speed = GetSpeed(isRun);

            _characterController.Move(direction * speed * Time.fixedDeltaTime);
        }

        private float GetSpeed(bool isRun) =>
            isRun ? _speed * _speedMultiply : _speed;
    }
}
