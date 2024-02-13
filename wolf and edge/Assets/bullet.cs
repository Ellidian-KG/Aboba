using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour

{
    public float speedes;
    public float bulletlife = 3f;
    
    private void FixedUpdate()
    {
         transform.Translate(-Vector3.left * Time.deltaTime * speedes, Space.World);
        
    }
    private void Awake()
    {
        Destroy(gameObject, bulletlife);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (GameObject.Find("dostat"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
               }

    }
}


