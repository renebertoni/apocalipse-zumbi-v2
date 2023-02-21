using UnityEngine;

public interface IMovement
{
    void DoMove(Vector2 position);
    void LookAtTarget(Vector2 position);
}
