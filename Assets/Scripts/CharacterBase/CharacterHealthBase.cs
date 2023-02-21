using UnityEngine;

public class CharacterHealthBase : MonoBehaviour, IDamage
{
    [SerializeField]
    protected int Health;

    public virtual void ReceiveDamage(int damage)
    {
        Health -= damage;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if(Health <= 0) Die();
    }

    public virtual void Die()
    {
        // TODO IMPLEMENTAR UM PADRAO PARA MORTE
        print("Nenhuma açao de morte implementada");
    }
}

