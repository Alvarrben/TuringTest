using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip shootSound;
    public AudioClip itemPickUp;
    public AudioClip drinkPotion;
    public AudioClip reload;
    public AudioClip delete;
    public AudioClip inventoryFull;

    public void LaunchShootSound()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }

    public void LaunchItemPickUpSound()
    {
        audioSource.clip = itemPickUp;
        audioSource.Play();
    }

    public void LaunchDrinkPotionSound()
    {
        audioSource.clip = drinkPotion;
        audioSource.Play();
    }

    public void LaunchReloadSound()
    {
        audioSource.clip = reload;
        audioSource.Play();
    }

    public void LaunchDeleteSound()
    {
        audioSource.clip = delete;
        audioSource.Play();
    }

    public void LaunchInventoryFullSound()
    {
        audioSource.clip = inventoryFull;
        audioSource.Play();
    }
}
