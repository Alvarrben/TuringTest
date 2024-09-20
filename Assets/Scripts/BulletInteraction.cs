using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletInteraction : MonoBehaviour, ObjectInteraction
{
    public Inventory inv;
    public GameManager gameManager;
    public void Use(InventoryScriptableObject invSO)
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.BulletsAdded();
        gameManager.SpawnNewBullet();
        gameManager.audioManager.LaunchReloadSound();
        inv.Remove(invSO, invSO.inventorySlot);
    }

    public void Delete(InventoryScriptableObject invSO)
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.SpawnNewBullet();
        gameManager.audioManager.LaunchDeleteSound();
        inv.Remove(invSO, invSO.inventorySlot);
    }
}