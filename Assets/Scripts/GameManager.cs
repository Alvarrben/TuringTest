using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //This can be transformed into a singletong if we need to keep it between scenes
{
    public Slider lifeBar;

    public int bulletsInChamber = 0;

    public GameObject bulletUI;

    public Transform potionSpawnPoint;
    public Transform bulletSpawnPoint;

    public GameObject potion;
    public GameObject bullet;
    public GameObject parentToSpawnedItems;

    public AudioManager audioManager;

    public void BulletsAdded()
    {
        bulletsInChamber++;
        if (!bulletUI.activeInHierarchy)
        {
            bulletUI.SetActive(true);
        }
        TextMeshProUGUI t = bulletUI.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        t.text = bulletsInChamber.ToString();
    }
    public void ShotFired()
    {
        bulletsInChamber--;

        TextMeshProUGUI t = bulletUI.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        t.text = bulletsInChamber.ToString();

        if(bulletsInChamber == 0)
        {
            DeactivateBulletUI();
        }
    }
    public void ActivateBulletUI()
    {
        bulletUI.SetActive(true);
    }
    public void DeactivateBulletUI()
    {
        bulletUI.SetActive(false);
    }
    public void SpawnNewPotion()
    {
        Instantiate(potion, potionSpawnPoint.position, potionSpawnPoint.rotation, parentToSpawnedItems.transform);
    }
    public void SpawnNewBullet()
    {
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation, parentToSpawnedItems.transform);
    }

}
