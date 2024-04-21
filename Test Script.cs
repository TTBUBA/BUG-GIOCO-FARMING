using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsPickUp;


    public void PickUp(int id)
    {
       bool result = inventoryManager.AddItem(itemsPickUp[id]);
        if (result == true)
        {
            Debug.Log("Adding");

        }
        else
        {
            Debug.Log("Adding");
        }    
    }
}
