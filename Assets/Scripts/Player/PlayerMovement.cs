using UnityEngine;

public class PlayerMovement : CharacterMovementBase
{
    private LayerMask _layermask;

    private void OnEnable(){
        PlayerInputs.Move += DoMove;
        PlayerInputs.Rotate += LookAtTarget;
    }

    private void OnDisable(){
        PlayerInputs.Move -= DoMove;
        PlayerInputs.Rotate -= LookAtTarget;
    }

    public override void DoMove(Vector2 input){
        var inputMove = input * Time.deltaTime * this._speed;
        this._characterController.Move( new Vector3(inputMove.x, 0, inputMove.y) );

        var speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);
        this._animator.SetFloat(Constants.Get.MOVE_SPEED, Mathf.Clamp(speed, 0, 1));
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
