using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaceExplostion : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    public void Explosion()
    {
        //create an explosion particel
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);
    }

}
