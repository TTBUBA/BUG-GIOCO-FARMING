using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color SelectColor, notSelectColor;



    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.color = SelectColor;
    }

    public void Deselect()
    {
        image.color  = notSelectColor;
    }

    // Metodo chiamato quando un oggetto viene rilasciato nell'area di questo slot
    public void OnDrop(PointerEventData eventData)
    {
        // Verifica se lo slot è vuoto (non contiene altri oggetti)
        if (transform.childCount == 0)
        {
            // Ottiene il componente InventoryItem dall'oggetto trascinato
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

            // Se l'oggetto trascinato è effettivamente un InventoryItem,
            // imposta il genitore dell'oggetto trascinato a questo slot
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
