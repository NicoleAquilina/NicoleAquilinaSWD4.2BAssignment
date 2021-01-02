using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 100;

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
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")* Time.deltaTime*moveSpeed;
        var nexXPos =Mathf.Clamp( transform.position.x + deltaX,xMin,xMax);

        transform.position = new Vector2(nexXPos, transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D otherOject)
    {
        //saving all the information of the DamageDealer objectLaser in dmg
        DamageDealer damage = otherOject.gameObject.GetComponent<DamageDealer>();
        Debug.Log("US HERE");
        // if the object does not have a damageDealer class end the method
        if (!damage) //if dmg does not exist
        {
            return;
        }

        ProcessHit(damage);
    }
    
    private void ProcessHit(DamageDealer damage)
    {
        health -= damage.getDamage();
        Debug.Log(health);
        //destroy the laser that hits the player
        damage.Hit();

        if(health <=0)
        {
            Destroy(gameObject);
        }
    }
   
   
}
