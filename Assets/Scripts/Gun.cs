using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject raycastOrigin;
    public GameManager gameManager;
    public Inventory inv;
    public ParticleSystem sparks;
    public ParticleSystem shoot;
    private void Awake()
    {
        inv = GameObject.Find("Game Manager").GetComponent<Inventory>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void Shoot()
    {
        if (gameManager.bulletsInChamber > 0)
        {
            sparks.Play();
            shoot.Play();
            RaycastHit hit;
            if (Physics.Raycast(raycastOrigin.transform.position, raycastOrigin.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(raycastOrigin.transform.position, raycastOrigin.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                gameManager.lifeBar.value -= 15;
            }

            gameManager.ShotFired();
            gameManager.audioManager.LaunchShootSound();
        }
    }
}
 