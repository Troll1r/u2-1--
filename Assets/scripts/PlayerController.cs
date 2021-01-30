using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class PlayerController : MonoBehaviourPunCallbacks
{
    InteractiveItem interactiveItem;
    RaycastHit hit;
    Camera cam;
    Weapon weapon;
    void Start()
    {
        if (photonView.IsMine)
        {
            GameManager.Instance().localPlayer = this;
            GameManager.Instance().HUD.enabled = true;

            cam = GetComponentInChildren<Camera>();
            weapon = GetComponentInChildren<Weapon>();

            cam.enabled = true;
            weapon.enabled = true;
            GetComponentInChildren<Camera>().enabled = true;
            GetComponent<CharacterController>().enabled = true;
            GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;

        }
    }

    void Update()

    {
        if (!photonView.IsMine) return;
        Physics.Raycast(
            cam.transform.position + cam.transform.forward,
            cam.transform.forward,
            out hit,
            3f);
        print(hit.collider?.gameObject.name);
        interactiveItem = hit.collider?
            .GetComponent<InteractiveItem>();

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Attack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactiveItem?.Use();
        }

        if (interactiveItem)
            GameManager.Instance().hintText.text = "Press E to use " +
                interactiveItem.ItemName;
        else
            GameManager.Instance().hintText.text = "";



    }
}
