using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;
    //in-built method
    //whenever our object hits our destoryer it triggers this function
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "obstacle")
        {
            //add score to GameSession Score
            Destroy(otherObject.gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

        }
        else
        {
            Destroy(otherObject.gameObject);
        }
            
    }
   

}
