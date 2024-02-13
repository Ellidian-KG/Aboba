using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            Debug.Log("sucsess");
            Destroy(other);
        }
    }
}
