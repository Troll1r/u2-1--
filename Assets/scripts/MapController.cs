using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public List<MapObject> mapObjects;

    [SerializeField] GameObject iconPrefab;
    [SerializeField] RectTransform radarPanel;
    [SerializeField] RectTransform playerIcon;

    [SerializeField][Range(1, 10)] float scale = 5;
    [SerializeField] float maxDistance, viewDistance;

    [SerializeField] Transform player;

    bool zoomed = false;
    private void Awake()
    {
        GameManager.Instance().mc = this;
        mapObjects = new List<MapObject>();
    }
    public void RegisterObject(MapObject mo)
    {
        // создать иконку и вложить в панель радара
        GameObject m = GameObject.Instantiate(iconPrefab, radarPanel);
        
        mo.icon = m.GetComponent<Image>();
        mo.icon.sprite = mo.sprite;
        //mo.owner = m.gameObject;

        // связать её с mo.icon

        mapObjects.Add(mo);
    } 
    public void RemoveObject(MapObject mo)
    {
        Destroy(mo.icon);
        mapObjects.Remove(mo);
    }
    void Update()
    {
        Vector3 tmp = Vector3.zero;
        tmp.z = GameManager.Instance().localPlayer.transform.rotation.eulerAngles.y;
        radarPanel.localRotation = Quaternion.Euler(tmp);

        playerIcon.localRotation = Quaternion.Euler(-tmp);

        foreach (MapObject mapObject in mapObjects)
        {
            // calc coords
            Vector3 rel = Vector3.zero;
            rel.x = mapObject.owner.transform.position.x - player.position.x - GameManager.Instance().localPlayer.transform.rotation.eulerAngles.y;
            rel.y = mapObject.owner.transform.position.z - player.position.z - GameManager.Instance().localPlayer.transform.rotation.eulerAngles.y;

            if (rel.magnitude > viewDistance)
            {
                mapObject.icon.enabled = false;
                continue;
            }
            else
                mapObject.icon.enabled = true;

            rel *= scale; // rel = rel * scale
            rel = Vector3.ClampMagnitude(rel, maxDistance);
            

            mapObject.icon.transform.localPosition = rel;
            mapObject.icon.transform.localRotation = Quaternion.Euler(-tmp);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            zoomed = !zoomed;
            scale = zoomed ? 10 : 5;
        }
    }
}
