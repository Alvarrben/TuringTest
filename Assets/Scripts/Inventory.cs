using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Dictionary<InventoryScriptableObject, InventoryItem> itemDictionary;
    public List<InventoryItem> inventoryItem { get; set; }
    public bool[] inventoryPositionOcupied { get; set; }
    public bool[] inventoryPositionIsTrash { get; set; }

    public GameObject inventoryUI;

    //To expand this feature i will probably change the images and texts into another List
    //And using the inventorySize variable create the number of necesary slots in the hierarchy
    public Image inv1;
    public Image inv2;
    public TextMeshProUGUI imgCounter1;
    public TextMeshProUGUI imgCounter2;

    public int objectToRemove;
    public int inventorySize = 2;

    public InventoryScriptableObject potionTrash;
    public InventoryScriptableObject bulletTrash;

    private void Awake()
    {
        inventoryItem = new List<InventoryItem>();
        itemDictionary = new Dictionary<InventoryScriptableObject, InventoryItem>();
        inventoryPositionOcupied = new bool[inventorySize];
        inventoryPositionIsTrash = new bool[inventorySize];
        InitializeArrays();
    }

    public void InitializeArrays()
    {

        for (int i = 0; i < inventorySize; i++)
        {
            inventoryPositionOcupied[i] = false;
        }
        for (int i = 0; i < inventorySize; i++)
        {
            inventoryPositionIsTrash[i] = false;
        }
    }

    public InventoryItem Get(InventoryScriptableObject referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }

    public int GetListPosition()
    {
        int p = -1;
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryPositionOcupied[i] == false)
            {
                p = i + 1; break;
            }
        }
        if (p == -1)
        {
            //inventory is full and the item shouldnt be addedd this can be used to expand the inventory system. For now i'll return p as well
            return p;
        }
        else
        {
            return p;
        }
    }

    public void Add(InventoryScriptableObject referenceData, int position)
    {

        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
            position = referenceData.inventorySlot;
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventoryItem.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
            inventoryUI.SetActive(true);

            if (referenceData.id == "4" || referenceData.id == "5") //it's trash and we have to set it on the corresponding position
            {
                inventoryPositionIsTrash[position - 1] = true;
                referenceData.inventorySlot = position;
            }
            else //not trash so we use the fist available position
            {
                position = GetListPosition(); //Get position to add the element in
                referenceData.inventorySlot = position;
                inventoryPositionOcupied[position - 1] = true;
            }
            SetImage(referenceData, position);
        }
        SetCounter(referenceData, position);
    }

    public void Remove(InventoryScriptableObject referenceData, int position)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            if (referenceData.id == "4" || referenceData.id == "5")  //if its garbage
            {
                value.stackSize = 0;
                inventoryPositionIsTrash[position - 1] = false;
                inventoryPositionOcupied[position - 1] = false;
                inventoryUI.transform.GetChild(position - 1).GetChild(0).gameObject.SetActive(false);
                inventoryUI.transform.GetChild(position - 1).gameObject.SetActive(false);//Turn off the icon and the buttons

                bool allChildDeactivated = true;
                for (int i = 0; i < inventorySize; i++)
                {
                    if (inventoryUI.transform.GetChild(i).gameObject.activeInHierarchy)
                    {
                        allChildDeactivated = false;
                        break;
                    }
                }
                if (allChildDeactivated)
                {
                    inventoryUI.SetActive(false);
                }
                itemDictionary.Remove(referenceData);
            }
            else  //If not
            {
                value.RemoveFromStack();

                if (value.stackSize == 0) //Set to trash
                {
                    inventoryItem.Remove(value);
                    if (referenceData.id == "1")
                    {
                        Add(potionTrash, referenceData.inventorySlot);
                    }
                    else if (referenceData.id == "2")
                    {
                        Add(bulletTrash, referenceData.inventorySlot);
                    }
                    referenceData.inventorySlot = -1;
                    itemDictionary.Remove(referenceData);
                }
                else //Adjust UI
                {
                    SetCounter(referenceData, position);
                }
            }
        }
    }
    public void SetImage(InventoryScriptableObject reference, int position)
    {
        switch (position)
        {
            case 1:
                inv1.gameObject.SetActive(true);
                inv1.sprite = reference.icon;
                break;
            case 2:
                inv2.gameObject.SetActive(true);
                inv2.sprite = reference.icon;
                break;
        }
    }
    public void SetCounter(InventoryScriptableObject reference, int position)
    {
        string stringToWrite = itemDictionary[reference].stackSize.ToString();

        switch (position)
        {
            case 1:
                if (reference.id != "4" && reference.id != "5")
                {
                    imgCounter1.text = stringToWrite;
                }
                else
                {
                    imgCounter1.text = "";
                }
                break;
            case 2:
                if (reference.id != "4" && reference.id != "5")
                {
                    imgCounter2.text = stringToWrite;
                }
                else
                {
                    imgCounter2.text = "";
                }
                break;
        }
    }
    public bool CanIPickThisItem(InventoryScriptableObject referenceData)
    {
        bool res = false;

        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value)) //Expand with check of item max stackSize in the future
        {
            res = true;
            return res;
        }
        else //Check if it's garbage its on the inventory
        {
            if (referenceData.id == "1")
            {
                if (itemDictionary.TryGetValue(potionTrash, out InventoryItem value2))
                {
                    return res;
                }
            }
            else if (referenceData.id == "2")
            {
                if (itemDictionary.TryGetValue(bulletTrash, out InventoryItem value2))
                {
                    return res;
                }
            }

            for (int i = 0; i < inventorySize; i++)
            {
                if (inventoryPositionOcupied[i] == false)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

    }

    [Serializable]
    public class InventoryItem
    {
        public InventoryScriptableObject data { get; private set; }
        public int stackSize { get; set; }

        public InventoryItem(InventoryScriptableObject source)
        {
            data = source;
            AddToStack();
        }

        public void AddToStack()
        {
            stackSize++;
        }

        public void RemoveFromStack()
        {
            stackSize--;
        }
    }

}





