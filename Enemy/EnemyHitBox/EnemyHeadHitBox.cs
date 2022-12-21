using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadHitBox : HitBox
{

    public override void Hit(float damage)
    {
        float finishDamage = damage * 4;
        base.Hit(finishDamage);
    }
}
