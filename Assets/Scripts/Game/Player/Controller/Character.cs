using Game.Mechanic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Jumpable))]
[RequireComponent(typeof(Rotatable))]
public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private SurfaceController _surfaceController;

    private Jumpable _jumpable;
    private Rotatable _rotatable;
    private Movement _movement;
    private CharacterController _controller;
    private Viewer _viewer;
    private float _velocity;
    private bool _isJump;
    private Vector3 _collisionNormal;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
        _rotatable = GetComponent<Rotatable>();
        _jumpable = GetComponent<Jumpable>();
        _viewer = new Viewer();
        _velocity = WorldPhysics.DefaultVelocity;

        _movement.Initialize(_controller);
    }

    private void FixedUpdate()
    {
        if (_surfaceController.OnGround && !_isJump)
            _velocity = WorldPhysics.DefaultVelocity;
        else
            DoGravity();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        float surfaceAngle = Vector3.Angle(Vector3.up, hit.normal);

        if (_velocity < WorldPhysics.DefaultVelocity && surfaceAngle > _controller.slopeLimit)
            _collisionNormal = hit.normal;
        else 
            _collisionNormal = Vector3.up;
    }

    public void Move(Vector3 direction, bool isRun)
    {
        direction = _viewer.GetDirectionToWorld(direction);

		_rotatable.Rotate(direction);
        _movement.MoveDirection(direction, isRun);
    }

	public void Jump()
    {
        if (_surfaceController.OnGround)
            _isJump = _jumpable.Jump(out _velocity);
        else
            _isJump = false;
    }

    private void DoGravity()
    {
        _velocity += WorldPhysics.Gravity * Time.fixedDeltaTime;

        _controller.Move((Vector3.up * _velocity + _collisionNormal) * Time.fixedDeltaTime);
    }
}
