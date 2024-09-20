using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class TrashInteraction : MonoBehaviour, ObjectInteraction
{
    public Inventory inv;
    public GameManager gameManager;

    public void Use(InventoryScriptableObject invSO)
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        inv.Remove(invSO, invSO.inventorySlot);
        gameManager.audioManager.LaunchDeleteSound();
    }

    public void Delete(InventoryScriptableObject invSO)
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        inv.Remove(invSO, invSO.inventorySlot);
        gameManager.audioManager.LaunchDeleteSound();
    }
}

