using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoad : MonoBehaviour
{
    public GameObject upgrade_manager;
    public GameObject audio_manager;
    public GameObject points_manager;
    void Awake()
    {
        if(FortunePoints.instance == null)
        {
            Instantiate(points_manager);
        }
        if (Upgrades.instance == null)
        {
            Instantiate(upgrade_manager);
        }

    }

}
