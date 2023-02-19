using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    void ReceiveDamage(int damage);
    void CheckHealth();
    void Die();
}
