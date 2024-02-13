using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterspistols : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pistol")
        {
            Destroy(other);
        }
    }
}
