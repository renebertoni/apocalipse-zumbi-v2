using UnityEngine;

[RequireComponent(typeof(PlayerStatus))]
public class PlayerMovement : MonoBehaviour
{
    PlayerStatus playerStatus;
    public LayerMask layermask;

    void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    void OnEnable()
    {
        PlayerInputs.Move += DoMove;
        PlayerInputs.Rotate += DoRotate;
    }

    void OnDisable()
    {
        PlayerInputs.Move -= DoMove;
        PlayerInputs.Rotate -= DoRotate;
    }

    void DoMove(Vector2 input)
    {
        var inputMove = input * Time.deltaTime * playerStatus.Speed;
        playerStatus.CharacterController.Move( new Vector3(inputMove.x, 0, inputMove.y) );
    }

    void DoRotate(Vector2 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layermask))
        {
            Vector3 lookPosition = hit.point;
            lookPosition.y = transform.position.y;
            transform.LookAt(lookPosition);
        }
    }
}
