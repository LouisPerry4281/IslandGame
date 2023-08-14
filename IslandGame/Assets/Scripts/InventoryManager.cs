using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    GameObject heldItem;
    Transform hand;
    PlayerAttack playerAttackScript;

    [SerializeField] GameObject[] objectReference;
    public Dictionary<int, int> quantities = new Dictionary<int, int>();

    private void Start()
    {
        hand = GameObject.Find("Hand").GetComponent<Transform>();
        playerAttackScript = GameObject.Find("First Person Player").GetComponent<PlayerAttack>();
    }

    public void AddToInventory(int id, int quantityToAdd)
    {
        quantities.TryGetValue(id, out int quantity);
        quantity += quantityToAdd;
        quantities.Remove(id);
        quantities.Add(id, quantity);
    }

    public void RemoveFromInventory(int id, int quantityToRemove)
    {
        quantities.TryGetValue(id, out int quantity);
        quantity -= quantityToRemove;
        quantities.Remove(id);
        quantities.Add(id, quantity);
    }

    public void EquipItem(int equipId)
    {
        if (heldItem != null)
            Destroy(heldItem);

        heldItem = Instantiate(objectReference[equipId], hand);

        heldItem.GetComponent<Rigidbody>().isKinematic = true;
        heldItem.GetComponent<Collider>().enabled = false;
        heldItem.transform.SetParent(hand);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.Euler(0, 0, 0);

        playerAttackScript.animator = heldItem.GetComponentInChildren<Animator>();
    }
}
