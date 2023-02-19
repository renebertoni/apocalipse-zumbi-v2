using UnityEngine;

[RequireComponent(typeof(PlayerStatus))]
public class PlayerAnimation : MonoBehaviour
{
    PlayerStatus playerStatus;

    void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    void OnEnable()
    {
        PlayerInputs.Move += DoMove;
    }

    void OnDisable()
    {
        PlayerInputs.Move -= DoMove;
    }

    void DoMove(Vector2 input)
    {
        var speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);
        playerStatus.Animator.SetFloat(Constants.Get.MOVE_SPEED, Mathf.Clamp(speed, 0, 1));
    }
}
