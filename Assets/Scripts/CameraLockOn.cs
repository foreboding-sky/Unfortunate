using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockOn : MonoBehaviour
{
    public Transform target;
    public float camSpeed = 15f;

    public Vector3 offset;
    void Start()
    {
        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        CamLock();
    }

    public void CamLock()
    {
        //Vector3 desiredPosition = target.position - offset;
        Vector3 desiredPosition = new Vector3(target.position.x - offset.x, transform.position.y, target.position.z - offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}