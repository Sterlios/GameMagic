using System;
using UnityEngine;
using static CharacterInputSystem;

public class CharacterInput : Inputable
{
    private PlayerActions _actions;

    public override void Awake()
    {
        base.Awake();

        CharacterInputSystem input = new CharacterInputSystem();
        input.Enable();
        _actions = input.Player;
    }

    protected override void ReadMove(out Vector3 direction, out bool isRun)
    {
        Vector2 direction2D = _actions.Move.ReadValue<Vector2>();
        direction = new Vector3(direction2D.x, 0, direction2D.y);

        isRun = _actions.Run.IsPressed();
    }

    protected override void ReadJump(out bool isJump)
    {
        isJump = _actions.Jump.IsPressed();
    }

    protected override IControllable GetIControllableComponent()
    {
        Character controllableObject = GetComponent<Character>();

        if (controllableObject == null)
            throw new Exception($"There is no IControllable component on the object: {gameObject.name}");

        return controllableObject;
    }
}
