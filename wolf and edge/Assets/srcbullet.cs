using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class srcbullet : MonoBehaviour
{
    public GameObject objbul, objwhere;
    public GameObject objclone;
    public int power;
    void Update()
    {
     
        objclone = Instantiate(objbul, objwhere.transform.position, Quaternion.identity);
        objclone.GetComponent<Rigidbody>().AddForce(objwhere.transform.forward * power);
    }
}

