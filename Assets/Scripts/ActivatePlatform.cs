using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlatform : MonoBehaviour
{
    [SerializeField] private MovingPlatform platform;

    private void Start()
    {
        platform.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>())
        platform.enabled = true;
    }
}
