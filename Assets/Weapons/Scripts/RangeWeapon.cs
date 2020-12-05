using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    GameObject bulletPrefab;

    int ammo;
    int clipAmmo;
    float reloadTime;
    public override void Attack()
    {
        base.Attack();
        print("pew");
    }
    public void Reload()
    {
        //
    }
}
