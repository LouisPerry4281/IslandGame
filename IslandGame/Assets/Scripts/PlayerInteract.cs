using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Delete Later
    [SerializeField] GameObject groundSpear;

    PlayerAttack playerAttackScript;
    Transform hand;

    GameObject heldItem;

    private void Start()
    {
        hand = GameObject.Find("Hand").GetComponent<Transform>();
        playerAttackScript = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupItem(groundSpear);
        }

        else if (Input.GetKeyDown(KeyCode.Q) && heldItem != null)
        {
            DropItem();
        }
    }

    private void PickupItem(GameObject itemToPickup)
    {
        heldItem = itemToPickup;

        itemToPickup.GetComponent<Rigidbody>().isKinematic = true;
        itemToPickup.GetComponent<Collider>().enabled = false;
        itemToPickup.transform.SetParent(hand);
        itemToPickup.transform.localPosition = Vector3.zero;
        itemToPickup.transform.localRotation = Quaternion.Euler(0, 0, 0);

        playerAttackScript.animator = GetComponentInChildren<Animator>();
    }

    private void DropItem()
    {
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem.GetComponent<Collider>().enabled = true;
        heldItem.transform.SetParent(null);

        playerAttackScript.animator = null;

        heldItem = null;
    }
}
