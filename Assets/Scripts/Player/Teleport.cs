using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private CharacterController player;
    public void TeleportTo(Transform destination)
    {
        player.enabled = false;
        player.transform.position = destination.position;
        player.enabled = true;
    }
}
