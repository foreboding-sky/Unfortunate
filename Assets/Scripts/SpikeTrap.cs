using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private Spikes spikes;
    private bool spikesReloaded;
    private bool canDamage;
    void Start()
    {
        canDamage = false;
        spikesReloaded = true;
        spikes = this.GetComponentInChildren<Spikes>();
    }
    void Update()
    {
        if (spikesReloaded)
        {
            canDamage = true;
            StartCoroutine(_TriggerSpikes());     
        }
    }
    IEnumerator _TriggerSpikes()
    {
        spikesReloaded = false;
        yield return new WaitForSeconds(cooldown);

        spikes.Shoot();
        this.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(cooldown);

        spikes.Retract();
        this.GetComponent<BoxCollider>().enabled = false;

        spikesReloaded = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        LifeSystem playerHealth = other.gameObject.transform.root.gameObject.GetComponent<LifeSystem>();

        if (playerHealth != null && canDamage)
        {
            Debug.Log("Spikes collided with the player");
            playerHealth.TakeDamage(damage);
            canDamage = false;
        }
    }
}
