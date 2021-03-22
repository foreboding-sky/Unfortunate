using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Vector3> points;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float waitTime = 1f;
    private Rigidbody rb;
    private bool isMoving = false;
    private float startTime;
    private Vector3 source;
    //private CharacterController player;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!isMoving)
            StartCoroutine(MovePlatform());
    }
    IEnumerator MovePlatform()
    {
        isMoving = true;     
        for (int i = 0; i < points.Count; i++)
        {
            startTime = Time.time;
            source = transform.position;
            while (Time.time < startTime + LerpTime(source, source + points[i]))
            {
                rb.MovePosition(transform.position + (points[i].normalized * Time.fixedDeltaTime * speed));
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(waitTime);
        }

        for (int i = points.Count - 1; i >= 0; i--)
        {
            startTime = Time.time;
            source = transform.position;
            while (Time.time < startTime + LerpTime(source, source + points[i]))
            {
                rb.MovePosition(transform.position - (points[i].normalized * Time.fixedDeltaTime * speed));
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(waitTime);
        }
        isMoving = false;
        yield return null;
    }
    private float LerpTime(Vector3 first, Vector3 second)
    {
        float res = (first - second).magnitude;
        return res / speed;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<CharacterController>(out CharacterController player))
        {
            player.Move(rb.velocity * Time.deltaTime);
        } 
    }    
}
