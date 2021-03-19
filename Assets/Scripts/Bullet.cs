using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private ParticleSystem destroyEffect;
    private bool canDamage;
    void Start()
    {
        canDamage = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        LifeSystem playerHealth = other.gameObject.transform.root.gameObject.GetComponent<LifeSystem>();

        if (playerHealth != null && canDamage)
        {
            Debug.Log("Bullet collided with the player");
            playerHealth.TakeDamage(damage);
            canDamage = false;
        }
        Vector3 position = other.ClosestPoint(transform.position);
        //Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        ParticleSystem hitVFX = Instantiate(destroyEffect, position, Quaternion.identity);
        Destroy(gameObject);
    }
}
