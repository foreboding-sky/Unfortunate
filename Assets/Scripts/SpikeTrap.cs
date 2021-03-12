using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float cooldown = 1f;
    [SerializeField] private Spikes spikes;
    private bool SpikesReloaded;
    private bool canDamage;
    void Start()
    {
        canDamage = false;
        SpikesReloaded = true;
        spikes = this.GetComponentInChildren<Spikes>();
    }
    void Update()
    {
        if (SpikesReloaded)
        {
            canDamage = true;
            StartCoroutine(_TriggerSpikes());     
        }
    }
    IEnumerator _TriggerSpikes()
    {
        SpikesReloaded = false;
        yield return new WaitForSeconds(cooldown);

        spikes.Shoot();
        this.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(cooldown);

        spikes.Retract();
        this.GetComponent<BoxCollider>().enabled = false;

        SpikesReloaded = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        LifeSystem playerHealth = other.gameObject.transform.root.gameObject.GetComponent<LifeSystem>();

        if (playerHealth != null && canDamage)
        {
            Debug.Log("OnTriggerEnter");
            playerHealth.TakeDamage(damage);
            canDamage = false;
        }
    }
}
