using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryScriptableObject referenceItem;
    Inventory inv;
    GameManager manager;

    private void Start()
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    public void OnHandlePickupItem()
    {
        if (inv.CanIPickThisItem(referenceItem))
        {
            inv.Add(referenceItem, -1);
            manager.audioManager.LaunchItemPickUpSound();
            Destroy(gameObject);
        }
        else
        {
            manager.audioManager.LaunchInventoryFullSound();
        }
    }
}
