using UnityEngine;
using System.Collections;

public interface IDamageable
{
    void TakeHit(int damage);
    bool IsDead();
}
