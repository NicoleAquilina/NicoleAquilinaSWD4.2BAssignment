using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaceExplostion : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;
    [SerializeField] int points = 5;
    int sum;

    public void Explosion()
    {
        //create an explosion particel
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);
    }

    public void Points()
    {
        sum += points;
        Debug.Log(sum);
    }
}
