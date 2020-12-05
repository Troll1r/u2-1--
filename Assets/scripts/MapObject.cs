using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    [SerializeField] public Sprite sprite;

    [SerializeField] public GameObject owner;
    public Image icon;
    // Start is called before the first frame update
    void Start()
    {
        owner = gameObject;
        GameManager.Instance().mc.RegisterObject(this);
    }
}
