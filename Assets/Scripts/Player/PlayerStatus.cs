using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{
    #region Components
        public InputActionReference Movement, Shoot, PointerPosition;
    #endregion

    #region Attibutes
        [HideInInspector]
        public static Vector3 Position;
    #endregion

    private void FixedUpdate(){
        Position = transform.position;
    }
}

