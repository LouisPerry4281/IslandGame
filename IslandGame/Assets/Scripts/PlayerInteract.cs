using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    //Delete Later
    [SerializeField] GameObject groundSpear;

    PlayerAttack playerAttackScript;

    public GameObject heldItem;

    private void Start()
    {
        playerAttackScript = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && heldItem != null)
        {
            DropItem();
        }
    }

    private void DropItem()
    {
        //Move DropItem to InvMan
        //Change this to utilize RemoveToInventory from InvMan
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem.GetComponent<Collider>().enabled = true;
        heldItem.transform.SetParent(null);

        playerAttackScript.animator = null;

        heldItem = null;
    }
}
