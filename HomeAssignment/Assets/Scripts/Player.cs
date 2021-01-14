using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 100;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    [SerializeField] AudioClip HealthReduction;
    [SerializeField] [Range(0, 1)] float HealthReductionSoundVolume = 0.75f;
    
    float xMin, xMax, yMin, yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void SetUpMoveBoundaries()
    {
        //instance of the camera
        Camera gameCamera = Camera.main;

        //Boundaries
        //xMin = 0 and xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x +padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        //yMin = 0 and yMax = 1
        // yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        //yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

        
    }

    public int GetHealth()
    {
        return health;
    }


    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")* Time.deltaTime*moveSpeed;
        var nexXPos =Mathf.Clamp( transform.position.x + deltaX,xMin,xMax);

        transform.position = new Vector2(nexXPos, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //saving all the information of the DamageDealer objectLaser in dmg
        DamageDealer damage = otherObject.gameObject.GetComponent<DamageDealer>();
        
        // if the object does not have a damageDealer class end the method
        if (!damage && otherObject.gameObject.tag == "obstacle") //if dmg does not exist
        {
            damage.Hit();

            return;
        }
        ProcessHit(damage);
    }
    
    private void ProcessHit(DamageDealer damage)
    {
        health -= damage.getDamage();
        AudioSource.PlayClipAtPoint(HealthReduction, Camera.main.transform.position, HealthReductionSoundVolume);
        damage.Hit();
        if (health <=0)
        {
            health = 0;
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        //create an explosion particel
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);
        FindObjectOfType<Level>().LoadGameOver();
    }
   
   
}
