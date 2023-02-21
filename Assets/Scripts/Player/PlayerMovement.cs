using UnityEngine;

public class PlayerMovement : CharacterMovementBase
{
    [SerializeField]
    private LayerMask _layermask;
    [HideInInspector]
    public static Vector3 Position{
        get{ return s_position; }
    }
    private static Vector3 s_position;

    private void OnEnable(){
        PlayerInputs.Move += DoMove;
        PlayerInputs.Rotate += LookAtTarget;
    }

    private void OnDisable(){
        PlayerInputs.Move -= DoMove;
        PlayerInputs.Rotate -= LookAtTarget;
    }

    private void FixedUpdate(){
        s_position = transform.position;
    }

    public override void DoMove(Vector2 input){
        var inputMove = input * Time.deltaTime * Speed;
        CharacterController.Move( new Vector3(inputMove.x, 0, inputMove.y) );

        var speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);
        Animator.SetFloat(Constants.Get.MOVE_SPEED, Mathf.Clamp(speed, 0, 1));
    }

    public override void LookAtTarget(Vector2 mousePosition){
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, _layermask)){
            Vector3 lookPosition = hit.point;
            lookPosition.y = transform.position.y;
            transform.LookAt(lookPosition);
        }
    }
}
