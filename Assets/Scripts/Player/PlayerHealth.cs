using System;

public class PlayerHealth : CharacterHealthBase
{
    public static Action OnDead;
    public static Action<int> OnDamage;
    public bool IsAlive = true;

    void OnEnable()
    {
        EnemyAttack.Hit += ReceiveDamage;
    }
    
    void OnDisable ()
    {
        EnemyAttack.Hit -= ReceiveDamage;
    }

    public override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(damage);
        OnDamage?.Invoke(Health);
    }

    public override void Die()
    {
        IsAlive = false;
        OnDead?.Invoke();
    }
}
