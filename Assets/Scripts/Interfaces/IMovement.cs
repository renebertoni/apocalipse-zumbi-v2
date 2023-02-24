using UnityEngine;

public interface IMovement
{
    void DoMove(Vector2 position);
    void LookAtTarget(Vector3 position, float ease);
}
