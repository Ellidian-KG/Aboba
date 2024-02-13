using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    
    public int speed;
    private void FixedUpdate()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * speed, Space.World);
        if (Enemy.score % 50 == 0 && Enemy.score>1)
        {
            speed +=1;
        }
    }
}

