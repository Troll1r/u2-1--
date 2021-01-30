using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RangeWeapon : Weapon
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawner;

    int ammo;
    int clipAmmo;
    float reloadTime;
    public override void Attack()
    {
        base.Attack();
        print("pew");
        GameObject b = PhotonNetwork.Instantiate(bulletPrefab.name,bulletSpawner.position,bulletSpawner.rotation);
        b.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 5.0f ,ForceMode.Impulse);

    }
    public void Reload()
    {
        //
    }
}
