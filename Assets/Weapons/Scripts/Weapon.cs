using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float time;
    public virtual void Attack()
    {
        print(gameObject.name + " attack");
    }
}
