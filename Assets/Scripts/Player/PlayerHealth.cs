using System;

public class PlayerHealth : CharacterHealthBase
{
    public static Action OnDead;
    public static Action<int> OnDamage;
    public bool IsAlive = true;

    private void OnEnable(){
        EnemyAttack.Hit += ReceiveDamage;
    }
    
    private void OnDisable (){
        EnemyAttack.Hit -= ReceiveDamage;
    }

    public override void ReceiveDamage(int damage){
        base.ReceiveDamage(damage);
        OnDamage?.Invoke(Health);
    }

    public override void Die(){
        IsAlive = false;
        OnDead?.Invoke();
    }
}
