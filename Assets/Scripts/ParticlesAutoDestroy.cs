using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAutoDestroy : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private float duration;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        duration = ps.main.duration;
        Destroy(this.gameObject, duration);
    }
}
