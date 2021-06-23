using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Int32 missileDamage;

    public Single path;

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnDestroy", path / GameData.projectileSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
