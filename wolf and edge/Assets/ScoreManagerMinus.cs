using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerMinus : MonoBehaviour
{
    static public int minusScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroyer") && Enemy.score >1)
        {
            minusScore -= 1;
        }
        Debug.Log(minusScore);
    }
}
