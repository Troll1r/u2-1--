using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Weapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Attack();
        
        
        }

        
    }
}
