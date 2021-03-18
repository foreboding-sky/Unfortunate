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
    private void OnCollisionEnter(Collision other)
    {
        LifeSystem playerHealth = other.gameObject.transform.root.gameObject.GetComponent<LifeSystem>();

        if (playerHealth != null && canDamage)
        {
            Debug.Log("Bullet collides with the player");
            playerHealth.TakeDamage(damage);
            canDamage = false;
        }
        ContactPoint contact = other.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        ParticleSystem hitVFX = Instantiate(destroyEffect, position, rotation);
        Destroy(gameObject);
    }
}
