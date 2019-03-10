using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -85) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y+0.14f, transform.position.y-0.14f, Mathf.PingPong(Time.time, 1)), transform.position.z);
    }
}