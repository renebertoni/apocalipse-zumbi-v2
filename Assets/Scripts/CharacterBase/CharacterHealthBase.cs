using UnityEngine;

public class CharacterHealthBase : MonoBehaviour, IDamage
{
    [SerializeField]
    protected int Health;

    public virtual void ReceiveDamage(int damage){
        Health -= damage;
        CheckHealth();
    }

    public void CheckHealth(){
        if(IsDead()){
            Die();
        }
    }

    public virtual void Die(){
        // TODO IMPLEMENTAR UM PADRAO PARA MORTE
        print("Nenhuma açao de morte implementada");
    }
    
    protected bool IsDead(){
        return Health <= 0;
    }
}

