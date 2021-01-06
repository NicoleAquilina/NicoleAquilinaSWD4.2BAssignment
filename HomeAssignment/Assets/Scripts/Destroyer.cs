using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //in-built method
    //whenever our object hits our destoryer it triggers this function
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        
        Destroy(otherObject.gameObject);
    }

}
