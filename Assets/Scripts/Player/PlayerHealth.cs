using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : CharacterHealthBase
{
    public static Action OnDead;
    public static Action<int> OnDamage;
    public bool IsAlive = true;

    private void OnEnable(){
        EnemyAttackTrigger.Hit += ReceiveDamage;
    }
    
    private void OnDisable (){
        EnemyAttackTrigger.Hit -= ReceiveDamage;
    }

    public override void ReceiveDamage(int damage){
        base.ReceiveDamage(damage);
        OnDamage?.Invoke(this._health);
    }

    public override void Die(){
        IsAlive = false;
        OnDead?.Invoke();
    }
}
