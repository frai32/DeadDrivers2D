﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
   public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public int playerNumber;
    
    public Boundary boundary;
    

    private float moveV;
    private float moveH;
    
    private Rigidbody2D playerRig;

  
    
    // Start is called before the first frame update
    void Start()
    {
        playerRig = GetComponent<Rigidbody2D>();

        
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         moveH = Input.GetAxis("Horizontal"+ playerNumber);
         moveV = Input.GetAxis("Vertical"+ playerNumber);

        moving();
        
        //playerRig.rotation = Quaternion.Euler(0,0,playerRig.velocity.x * -tilt);

        playerRig.position = new Vector2(
          Mathf.Clamp(playerRig.position.x, boundary.xMin, boundary.xMax),
          Mathf.Clamp(playerRig.position.y, boundary.yMin, boundary.yMax));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tags tag = new Tags();
        if(collision.CompareTag(tag.getEnemyBoltTag))
        {
            Destroy(collision.gameObject);
            GetComponent<health>().TakeDamage();
        }

        if (collision.CompareTag(tag.getMainBoltTag))
        {
            Destroy(collision.gameObject);
            GetComponent<health>().TakeDamage(30);
        }

        if (collision.CompareTag(tag.getBossTag))
        {
            
            GetComponent<health>().TakeDamage(100);
        }
    }

    void moving()
    {
        Vector2 move = new Vector2(moveH, moveV);

        playerRig.velocity = move * speed;
    }

}
