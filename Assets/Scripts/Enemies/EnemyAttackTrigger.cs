using UnityEngine;
using System;

public class EnemyAttackTrigger : MonoBehaviour
{
    public static Action Hit;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Constants.Get.PLAYER))
            Hit?.Invoke();
    }
}
