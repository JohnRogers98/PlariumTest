using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{
    public GameObject tankPrefab;

    public Tower towerPrefab;

    private Body body = new Body();

    public Boolean isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        body.InitializeStates(BodyLevelRandomizer());

        towerPrefab.InitializeStates(TowerLevelRandomizer());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        Rigidbody rigidbody = tankPrefab.GetComponent<Rigidbody>();


        if (Input.GetKey(KeyCode.UpArrow))
        {              
            Vector3 pos = tankPrefab.transform.position;
            pos.z += body.Speed * Time.deltaTime;
            rigidbody.MovePosition(pos);

            tankPrefab.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 pos = tankPrefab.transform.position;
            pos.z += -body.Speed * Time.deltaTime;
            rigidbody.MovePosition(pos);

            tankPrefab.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 pos = tankPrefab.transform.position;
            pos.x += -body.Speed * Time.deltaTime;
            rigidbody.MovePosition(pos);

            tankPrefab.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 pos = tankPrefab.transform.position;
            pos.x += body.Speed * Time.deltaTime;
            rigidbody.MovePosition(pos);

            tankPrefab.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.tag == "missile")
        {
            Boolean isAlive = body.DecreaseHealth(1);

            if (isAlive == false)
            {
                OnDestroy();
            }

            Destroy(collisionObject.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (isPlayer == false)
            Destroy(tankPrefab.gameObject);
        else
            SceneManager.LoadScene("_Scene_0");
    }



    private BodyLevel BodyLevelRandomizer()
    {
        return (BodyLevel)UnityEngine.Random
            .Range((Int32)BodyLevel.LevelOne, (Int32)BodyLevel.LevelThree);
    }
    private TowerLevel TowerLevelRandomizer()
    {
        return (TowerLevel)UnityEngine.Random
            .Range((Int32)TowerLevel.LevelOne, (Int32)TowerLevel.LevelThree);
    }
    private DuloType DuloTypeRandomizer()
    {
        return (DuloType)UnityEngine.Random
            .Range((Int32)DuloType.TwoBarrelDulos, (Int32)DuloType.OneBarrelDulo);
    }
}

public enum BodyLevel
{
    LevelOne,
    LevelTwo,
    LevelThree
}

public enum TowerLevel
{
    LevelOne,
    LevelTwo,
    LevelThree
}

public enum DuloType
{
    TwoBarrelDulos,
    OneBarrelDulo
}





