using UnityEngine;

public class EnemyAttackSFX_animator : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       var enemyAttack = animator.gameObject.GetComponent<EnemyAttack>();
       enemyAttack.PlaySound();
    }
}
