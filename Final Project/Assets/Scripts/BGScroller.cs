using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    private Vector3 startPosition;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        if (gameController.winCondition == true)
        {
            if (scrollSpeed >= -15)
            {
                scrollSpeed -= Time.deltaTime;
            }
        }
        if (gameController.winCondition == false)
        {
            if (scrollSpeed <= -1.25f)
            {
                    scrollSpeed += Time.deltaTime;
            }
        }
    }   
}