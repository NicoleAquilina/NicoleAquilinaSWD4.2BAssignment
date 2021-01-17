using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;
    [SerializeField] AudioClip HealthReduction;
    [SerializeField] [Range(0, 1)] float HealthReductionSoundVolume = 0.75f;
    //in-built method
    //whenever our object hits our destoryer it triggers this function
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.tag == "obstacle")
        {
            //add score to GameSession Score
            Destroy(otherObject.gameObject);
            AudioSource.PlayClipAtPoint(HealthReduction, Camera.main.transform.position, HealthReductionSoundVolume);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);

        }
        else
        {
            Destroy(otherObject.gameObject);
        }
            
    }
   

}
