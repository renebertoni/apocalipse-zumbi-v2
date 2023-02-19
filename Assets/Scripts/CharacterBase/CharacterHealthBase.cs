using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthBase : MonoBehaviour, IDamage
{
    [SerializeField]
    protected int _health;

    public virtual void ReceiveDamage(int damage){
        _health -= damage;
        CheckHealth();
    }

    public void CheckHealth(){
        if(IsDead()){
            Die();
        }
    }

    public virtual void Die(){
        print("metodo do character");
    }
    
    protected bool IsDead(){
        return _health <= 0;
    }
}

