using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CilcularTrap : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * rotationSpeed);
    }
}
