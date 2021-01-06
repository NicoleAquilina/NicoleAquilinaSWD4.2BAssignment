using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject obstacleLaserPrefab;
    [SerializeField] float obstacleLaserSpeed = 10f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    // Start is called before the first frame update
    void Start()
    {
        //generate a random number
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);

    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    //count down shotCounter to 0 and shoot
    private void CountDownAndShoot()
    {
        //every frame reduce the amount of time of shotCounter
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            ObstacleFire();
            //reset shotCounter after every fire.
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    //spawn an obstacle Laser from the Obstacle's position
    private void ObstacleFire()
    {
        GameObject enemyLaser = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.identity);

        //obstacle laser shoots downwards, hence -obstacleLaserSpeed
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed);

    }
    //private void OnTriggerEnter2D(Collider2D otherObject)
    //{
    //    //saving all the information of the DamageDealer objectLaser in dmg
    //    DamageDealer damage = otherObject.gameObject.GetComponent<DamageDealer>();
    //    // if the object does not have a damageDealer class end the method
    //    if (!damage) //if dmg does not exist
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        damage.Hit();
    //        //create an explosion particel
    //        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
    //        //destroy after 1 sec
    //        Destroy(explosion, 1f);

    //    }

    //}

}
