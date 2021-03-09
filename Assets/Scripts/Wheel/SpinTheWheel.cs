using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class SpinTheWheel : MonoBehaviour
{

    [SerializeField] private Rigidbody rigid_body;
    [SerializeField] private float spin_strenght;

    float turn = -1;
    [SerializeField] float timer = 0, max_time=0;
    bool can_spin = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && can_spin == true)
        {
            WheelSpin();

        }
    }
    void WheelSpin()
    {
        can_spin = false;
        max_time = UnityEngine.Random.Range(10, 100);
        while (timer < max_time)
        {                     
            rigid_body.AddTorque(transform.up * spin_strenght * turn);
           
            timer += Time.deltaTime;
        }
        timer = 0;
        can_spin = true;

    }
}
