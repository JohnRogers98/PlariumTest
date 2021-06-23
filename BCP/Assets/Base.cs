using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    private Int32 health = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.tag == "missile")
        {
            Boolean isAlive = DecreaseHealth();
            if (isAlive == false)
            {
                OnDestroy();
            }

            Destroy(collisionObject.gameObject);
        }
    }

    private Boolean DecreaseHealth()
    {
        health -= 1;
        Boolean isAlive = false;

        if (health > 0)
        {
            isAlive = true;
        }
        return isAlive;
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("_Scene_0");
    }

}
