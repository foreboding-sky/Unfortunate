using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance = null;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    public int max_hearts = 3;
    public int curr_hearts = 6;
    public float dash_cd = 3f;
    public float jump_force = 15f;
    public int jump_number = 2;
    public float gravity = 50f;
    public float dash_speed = 100f;
    public float move_speed = 10f;
    public float rotation_speed = 50f;
    public float start_dash_time = 0.1f;

}
