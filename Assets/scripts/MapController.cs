using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public List<MapObject> mapObjects;
    private void Awake()
    {
        mapObjects = new List<MapObject>();

    
    
    }
    public void RegisterObject(MapObject mo)
    {
        //создать иконку и вложить в панель радара
        //связать ее с mo.icon
        mapObjects.Add(mo);
    }
    public void RemoveObject(MapObject mo)
    {
        Destroy(mo.icon);
        mapObjects.Remove(mo);
    
    
    }
    void Update()
    { 
        
    }
}
