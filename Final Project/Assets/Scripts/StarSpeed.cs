using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpeed : MonoBehaviour
{
    private GameController gameController;
    private ParticleSystem ps;
    private float hSliderValue = 1.0F;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;
        if (gameController.winCondition == true)
        {
            if (hSliderValue <= 15)
            {
                hSliderValue += Time.deltaTime;
            }
        }
        if (gameController.winCondition == false)
        {
            if (hSliderValue >= 1)
            {
                hSliderValue -= Time.deltaTime;
            }
        }
    }
}
