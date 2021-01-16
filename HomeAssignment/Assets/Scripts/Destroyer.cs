using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] int gamePoints = 5;
    //in-built method
    //whenever our object hits our destoryer it triggers this function
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "obstacle")
        {
            //add score to GameSession Score
            FindObjectOfType<GameSession>().AddToScore(gamePoints);
            Destroy(otherObject.gameObject);
            
        }
        else
        {
            Destroy(otherObject.gameObject);
        }
            
    }
   

}
