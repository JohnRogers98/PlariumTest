using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Dulo duloBodyPrefab;

    public Single accuracyOfFire;

    public delegate Boolean Accuracy();

    // Start is called before the first frame update
    void Start()
    {
        duloBodyPrefab.accuracy = AccuracyWheel;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private Boolean AccuracyWheel()
    {
        Boolean mistake = false; 
        Single randomValue = UnityEngine.Random.Range(0.0f, 1.0f);

        if (randomValue > accuracyOfFire)
        {
            mistake = true;
        }
        return mistake;
    }

    public void InitializeStates(TowerLevel level)
    {
        if (level == TowerLevel.LevelOne)
        {
            accuracyOfFire = 0.7f;
        }
        if (level == TowerLevel.LevelTwo)
        {
            accuracyOfFire = 0.8f;
        }
        if (level == TowerLevel.LevelThree)
        {
            accuracyOfFire = 0.9f;
        }
    }
}
