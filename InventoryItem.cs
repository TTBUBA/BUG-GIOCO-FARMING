using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    
    public Image image;
    public Text countText;
    // Variabile per memorizzare il genitore dopo il trascinamento
    [HideInInspector] public Transform parentAfterDrag;
    //[HideInInspector] public Item item;
    [HideInInspector] public int Count = 1;


    // RectTransform del Canvas
    private RectTransform canvasRectTransform;


    public Item item;

    private void OnMouseOver()
    {
        if (item != null && item.type == ItemType.Building && item.actionType == ActionType.Dig)
        {
            if (Input.GetMouseButtonDown(1) && InventoryManager.instance.currentItem == item)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.CompareTag("Terreno"))
                {
                    // Crea l'ortaggio sulla posizione del clic
                    // Assicurati di inserire qui il codice per la creazione dell'ortaggio
                    Debug.Log("Carota creata");
                }
            }
        }
    }

 



    private void Start()
    {
        // Ottiene il RectTransform del Canvas
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        InitaliseItem(item);
       
    }

    public void InitaliseItem(Item newitem)
    {
        item = newitem;
        image.sprite = newitem.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = Count.ToString();
        bool textActive = Count > 1 ;
        countText.gameObject.SetActive(textActive);
    }
    // Metodo chiamato quando inizia il trascinamento
    public void OnBeginDrag(PointerEventData eventData)
    {
  
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        InventoryManager.instance.SetCurrentItem(item);

    }

    // Metodo chiamato durante il trascinamento
    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        transform.localPosition = localPoint;
    }

    // Metodo chiamato quando termina il trascinamento
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);

       
    }

    

   
}
        

   


