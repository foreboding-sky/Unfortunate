using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomTrapSpawn : MonoBehaviour
{

    void Start()
    {
        if (Random.Range(1f,10f) > 7)
        {
            gameObject.SetActive(false);
        }
        
    }

}
