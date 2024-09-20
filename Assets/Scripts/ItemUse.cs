using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ItemUse : MonoBehaviour
{
    private Inventory inv;
    public InventoryScriptableObject aux;

    private void Awake()
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
    }

    public void ShowOptions()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HideOptions()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ToggleOptions()
    {
        this.transform.GetChild(0).gameObject.SetActive(!this.transform.GetChild(0).gameObject.activeInHierarchy);
    }

    public void Use(int position)
    {
        foreach (InventoryScriptableObject o in inv.itemDictionary.Keys)
        {
            if (o.inventorySlot == position)
            {
                aux = o;
                break;                
            }
        }
        ObjectInteraction objectInteraction = (ObjectInteraction)aux.prefab.GetComponent(aux.displayName + "Interaction");
        objectInteraction.Use(aux);
    }

    public void Delete(int position)
    {
        foreach (InventoryScriptableObject o in inv.itemDictionary.Keys)
        {
            if (o.inventorySlot == position)
            {
                aux = o;
                break;                
            }
        }
        ObjectInteraction objectInteraction = (ObjectInteraction)aux.prefab.GetComponent(aux.displayName + "Interaction");
        objectInteraction.Delete(aux);
    }
}
