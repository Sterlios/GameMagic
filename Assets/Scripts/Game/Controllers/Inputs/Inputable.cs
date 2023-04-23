using System;
using UnityEngine;

public abstract class Inputable : MonoBehaviour
{
    private IControllable _controllableObject;
    private Vector3 _direction;
    private bool _isJump;
    private bool _isRun;

    public virtual void Awake()
    {
        _controllableObject = GetIControllableComponent();
    }

    private void Update()
    {
        InitDirection();
        SetJumpPossible();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    protected abstract IControllable GetIControllableComponent();

    protected abstract void ReadJump(out bool isJump);

    protected abstract void ReadMove(out Vector3 direction, out bool isRun);

    protected virtual void Jump()
    {
        if (_isJump)
            _controllableObject.Jump();
    }

    protected virtual void Move()
    {
        if (_direction != Vector3.zero)
            _controllableObject.Move(_direction, _isRun);
    }

    private void InitDirection()
    {
        ReadMove(out Vector3 direction, out bool isRun);

        _direction = direction.normalized;
        _isRun = isRun;
    }

    private void SetJumpPossible()
    {
        ReadJump(out bool isJump);

        _isJump = isJump;
    }
}
