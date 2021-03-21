using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private Transform checkpoint;
    void OnTriggerEnter(Collider other)
    {
        LifeSystem playerHealth;
        Teleport player;
        if(player = other.gameObject.GetComponent<Teleport>())
        {
            Debug.Log("Got Teleport!");
            player.TeleportTo(checkpoint);
        }
        if (playerHealth = other.gameObject.GetComponent<LifeSystem>())
        {
            Debug.Log("Got playerHealth!");
            playerHealth.TakeDamage(damage);
        }
    }
}