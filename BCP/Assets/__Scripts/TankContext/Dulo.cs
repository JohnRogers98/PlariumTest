using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dulo : MonoBehaviour
{
    public Missile missilePrefab;

    Int32 duloCount;

    public Single maxPathOfMissile = 5.0f;

    public Tower.Accuracy accuracy;

    // Start is called before the first frame update
    void Start()
    {
        duloCount = this.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AllDulosFire();
        }
    }


    private void AllDulosFire()
    {
        for (Int32 duloNumber = 0; duloNumber < duloCount; duloNumber++)
        {
            Fire(duloNumber);
        }
    }


    private void Fire(Int32 duloNumber)
    {
        GameObject duloGO = transform.GetChild(duloNumber).gameObject;
        
        Missile missileGO = MissileInitialization(duloGO);

        SetForceToMissile(missileGO);
    }
    
    private Missile MissileInitialization(GameObject gameObject)
    {
        Transform startPoint = gameObject.transform.GetChild(0);

        Missile missileGO = Instantiate<Missile>(missilePrefab, startPoint.position, startPoint.localRotation);

        Vector3 forwardPosition = startPoint.forward;
        missileGO.transform.forward = forwardPosition;

        missileGO.path = maxPathOfMissile;
        Debug.Log(missileGO.path + "   " + maxPathOfMissile);

        return missileGO;
    }

    private void SetForceToMissile(Missile missileGO)
    {
        Rigidbody rigidBody = missileGO.GetComponent<Rigidbody>();

        Boolean mistake = accuracy();      

        if (mistake == true)
        {
            rigidBody.AddForce(new Vector3(
                missileGO.transform.forward.x + 5.0f,
                missileGO.transform.forward.y + 3.0f,
                missileGO.transform.forward.z + 5.0f
                ), ForceMode.Impulse);
        }
        else
        {
            rigidBody.AddForce(missileGO.transform.forward * GameData.projectileSpeed, ForceMode.Impulse);
        }
    }
}
