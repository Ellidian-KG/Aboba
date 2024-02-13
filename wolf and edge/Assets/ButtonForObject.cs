using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForObject : MonoBehaviour
{
    ObjectSpawner neededScript;
    private void Start()
    {
        neededScript = GameObject.FindGameObjectWithTag("dostat").GetComponent<ObjectSpawner>();
    }
    
    
    }