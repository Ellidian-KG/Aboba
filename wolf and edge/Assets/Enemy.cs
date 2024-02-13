using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ochko ;
    public GameObject dostat;
    public int Health = 3;
    public static int score;
    public void TakeDamage(int damage)
    {
        if (Health > damage)
        {
            Health -= damage;
        }
        else
        {
            Destroy(gameObject);
            score += ochko;
          
          
        }
        
    }
   

}
