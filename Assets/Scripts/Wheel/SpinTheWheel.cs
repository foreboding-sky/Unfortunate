using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpinTheWheel : MonoBehaviour
{

    [SerializeField] private Rigidbody rigid_body;
    [SerializeField] private float spin_strenght;

    float turn;
    [SerializeField] float timer;
    bool is_spinning;
    // Start is called before the first frame update
    void Start()
    {
        is_spinning = false;
        timer = 0;
        turn = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && is_spinning == false)
        {
            SetTimer();
        }
        WheelSpin();
    }
    void WheelSpin()
    {
        if (timer > 0)
        {
            rigid_body.AddTorque(transform.up * spin_strenght * turn);

            timer -= Time.deltaTime;
        }

        if (timer < 0 && rigid_body.angularVelocity.y == 0)
        {
            
            is_spinning = false;
            Debug.Log(transform.localEulerAngles.y);
            SelectLevel(transform.localEulerAngles.y);
        }
    }
    void SetTimer()
    {
        is_spinning = true;
        timer = UnityEngine.Random.Range(1, 10);            
    }
    void SelectLevel(float angle)
    {
        switch (angle)
        {
            case var n when (n >= 0 && n < 45):
                SceneManager.LoadScene(1);
                break;
            case var n when (n >= 45 && n < 90):
                SceneManager.LoadScene(2);
                break;
            case var n when (n >= 90 && n < 135):
                SceneManager.LoadScene(3);
                break;
            case var n when (n >= 135 && n < 180):
                SceneManager.LoadScene(4);
                break;
            case var n when (n >= 180 && n < 225):
                SceneManager.LoadScene(5);
                break;
            case var n when (n >= 225 && n < 270):
                SceneManager.LoadScene(6);
                break;
            case var n when (n >= 270 && n < 315):
                SceneManager.LoadScene(7);
                break;
            case var n when (n >= 315 && n < 360):
                SceneManager.LoadScene(8);
                break;
        }
    }
}
