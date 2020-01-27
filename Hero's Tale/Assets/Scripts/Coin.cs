using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Hero")
            Destroy(gameObject);
    }
}