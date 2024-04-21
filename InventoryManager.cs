using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public int maxStackItems = 5;
    public GameObject inventoryprefabs;

    public int Selectslot = -1;

    public static InventoryManager instance;

    public Item currentItem; // Memorizza l'oggetto correntemente selezionato nell'inventario

    private void Awake()
    {
        instance = this;
    }

    public void SetCurrentItem(Item item)
    {
        currentItem = item;
    }



    public void Start()
    {
        ChangeColorSelect(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeColorSelect(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeColorSelect(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeColorSelect(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeColorSelect(3);
        }
        else if  (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeColorSelect(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeColorSelect(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ChangeColorSelect(6);
        }
    }

    void ChangeColorSelect(int newValue)
    {
        if(Selectslot >=0)
        {
            inventorySlots[Selectslot].Deselect();
        }
        

        inventorySlots[newValue].Select();
        Selectslot = newValue;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemslot = slot.GetComponentInChildren<InventoryItem>();

            if (itemslot != null && itemslot.item == item && itemslot.Count < maxStackItems && itemslot.item.stackable)
            {
                itemslot.Count++;
                itemslot.RefreshCount();
                return true;
            }
        }

        


        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemslot = slot.GetComponentInChildren<InventoryItem>();
            if (itemslot == null)
            {
                SpawNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    public void SpawNewItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryprefabs, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponentInChildren<InventoryItem>();
        inventoryItem.InitaliseItem(item);
    }

    

}
