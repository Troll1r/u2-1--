using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    public string ItemName;
    public void Use()
    {
        Destroy(gameObject);
    }
}
