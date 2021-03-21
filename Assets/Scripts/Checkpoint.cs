using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpoint;
    //GameObject player;
    // Use this for initialization
    void Start()
    {

        //player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.tag == "Player")
        {
            Debug.Log(plyr.transform.position);
            Debug.Log(plyr.transform.rotation);
            Transform player = plyr.gameObject.transform.root.gameObject.GetComponent<Transform>();
            //LifeSystem playerHealth = other.gameObject.transform.root.gameObject.GetComponent<LifeSystem>();
            player.transform.position = checkpoint.transform.position;
            player.transform.rotation = checkpoint.transform.rotation;
            //player.transform.SetPositionAndRotation(checkpoint.transform.position, checkpoint.transform.rotation);
            Debug.Log(checkpoint.transform.position);
            Debug.Log(checkpoint.transform.rotation);
            Debug.Log(player.transform.position);
            Debug.Log(player.transform.rotation);
        }
    }
}