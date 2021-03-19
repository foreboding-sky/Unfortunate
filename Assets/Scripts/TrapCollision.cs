using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        LifeSystem playerHealth = other.gameObject.transform.root.gameObject.GetComponent<LifeSystem>();

        if (playerHealth != null)
        {
            Debug.Log("Pendulum collided with the player");
            playerHealth.TakeDamage(damage);
        }
    }
}
