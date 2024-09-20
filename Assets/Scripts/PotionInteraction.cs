using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotionInteraction : MonoBehaviour, ObjectInteraction
{
    public Inventory inv;
    public GameManager gameManager;

    public void Use(InventoryScriptableObject invSO)
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.lifeBar.value += 20;
        gameManager.SpawnNewPotion();
        gameManager.audioManager.LaunchDrinkPotionSound();
        inv.Remove(invSO, invSO.inventorySlot);
    }

    public void Delete(InventoryScriptableObject invSO)
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SpawnNewPotion();
        gameManager.audioManager.LaunchDeleteSound();
        inv.Remove(invSO, invSO.inventorySlot);
    }
}

