using UnityEngine;

public interface IControllable
{
    void Move(Vector3 direction, bool IsRun = false);
    void Jump();
}
