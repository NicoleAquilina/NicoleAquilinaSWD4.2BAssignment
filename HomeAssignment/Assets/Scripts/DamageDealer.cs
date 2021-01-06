using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    //Returns the amount of damage
    public int getDamage()
    {
        return damage;
    }
    //destroys the gameObject
    public void Hit()
    {
        Destroy(gameObject);
        //create an explosion particel
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);
    }
}

