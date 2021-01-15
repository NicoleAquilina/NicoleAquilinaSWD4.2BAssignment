using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;


    //Returns the amount of damage
    public int getDamage()
    {
        return damage;
    }
   
    //destroys the gameObject
    public void Hit()
    {
        Destroy(gameObject);
        

    }
}

