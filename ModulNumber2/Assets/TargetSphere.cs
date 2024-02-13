using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSphere : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sphere")
        {
            Debug.Log("sucsess");
            Destroy(other);
        }
    }
}
