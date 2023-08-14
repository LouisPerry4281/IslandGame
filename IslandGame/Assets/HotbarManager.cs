using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    InventoryManager inventoryManager;

    public int[] hotbarReferences = new int[9];

    private void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            inventoryManager.EquipItem(hotbarReferences[0]);

        else if (Input.GetKeyDown(KeyCode.Alpha2) && hotbarReferences[1] != 0)
            inventoryManager.EquipItem(hotbarReferences[1]);

        else if (Input.GetKeyDown(KeyCode.Alpha3) && hotbarReferences[2] != 0)
            inventoryManager.EquipItem(hotbarReferences[2]);

        else if (Input.GetKeyDown(KeyCode.Alpha4) && hotbarReferences[3] != 0)
            inventoryManager.EquipItem(hotbarReferences[3]);

        else if (Input.GetKeyDown(KeyCode.Alpha5) && hotbarReferences[4] != 0)
            inventoryManager.EquipItem(hotbarReferences[4]);

        else if (Input.GetKeyDown(KeyCode.Alpha6) && hotbarReferences[5] != 0)
            inventoryManager.EquipItem(hotbarReferences[5]);

        else if (Input.GetKeyDown(KeyCode.Alpha7) && hotbarReferences[6] != 0)
            inventoryManager.EquipItem(hotbarReferences[6]);

        else if (Input.GetKeyDown(KeyCode.Alpha8) && hotbarReferences[7] != 0)
            inventoryManager.EquipItem(hotbarReferences[7]);

        else if (Input.GetKeyDown(KeyCode.Alpha9) && hotbarReferences[8] != 0)
            inventoryManager.EquipItem(hotbarReferences[8]);
    }

    public void AssignToHotbar(int keyToAssign, int idToAssign)
    {
        hotbarReferences[keyToAssign - 1] = idToAssign;
    }


}
