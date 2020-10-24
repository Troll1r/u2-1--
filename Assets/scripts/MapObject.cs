using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] GameObject owner;
    public Image icon;


    void Start()
    {
        FindObjectOfType<MapController>().RegisterObject(this);
    }

    void Update()
    {
        
    }
}
