using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject[] objectReference;
    public Dictionary<int, int> quantities = new Dictionary<int, int>();


    public void AddToInventory(int id, int quantityToAdd)
    {
        quantities.TryGetValue(id, out int quantity);
        quantity += quantityToAdd;
        quantities.Remove(id);
        quantities.Add(id, quantity);

        /*
        int printValue;
        quantities.TryGetValue(id, out printValue);
        print(id + " " + printValue);
        */
    }

    public void RemoveFromInventory(int id, int quantityToRemove)
    {
        quantities.TryGetValue(id, out int quantity);
        quantity -= quantityToRemove;
        quantities.Remove(id);
        quantities.Add(id, quantity);

        /*
        int printValue;
        quantities.TryGetValue(id, out printValue);
        print(id + " " + printValue);
        */
    }
}
