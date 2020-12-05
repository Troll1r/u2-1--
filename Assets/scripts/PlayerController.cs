using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    InteractiveItem interactiveItem;
    RaycastHit hit;
    Camera cam;
    [SerializeField] Text hintText;
    Weapon weapon;
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        weapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        Physics.Raycast(
            cam.transform.position + cam.transform.forward,
            cam.transform.forward,
            out hit,
            3f);
        print(hit.collider?.gameObject.name);
        interactiveItem = hit.collider?
            .GetComponent<InteractiveItem>();

        if (interactiveItem)
            hintText.text = "Press E to use " +
                interactiveItem.ItemName;
        else
            hintText.text = "";

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Attack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactiveItem?.Use();
        }

    }
}
