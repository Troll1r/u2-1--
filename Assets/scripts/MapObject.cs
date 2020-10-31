using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public GameObject owner;
    public Image icon;


    void Start()
    {
        owner = gameObject;
        FindObjectOfType<MapController>().RegisterObject(this);
    }

    void Update()
    {
        
    }
}
