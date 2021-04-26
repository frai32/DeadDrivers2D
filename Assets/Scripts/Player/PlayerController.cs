using System.Collections;
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
    
    public Boundary boundary;
    

    float moveV;
    float moveH;
    
    Rigidbody2D playerRig;
    
    
    
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
         moveH = Input.GetAxis("Horizontal");
         moveV = Input.GetAxis("Vertical");

        moving();
        
        //playerRig.rotation = Quaternion.Euler;

        playerRig.position = new Vector2(
          Mathf.Clamp(playerRig.position.x, boundary.xMin, boundary.xMax),
          Mathf.Clamp(playerRig.position.y, boundary.yMin, boundary.yMax));

    }

    void moving()
    {
        Vector2 move = new Vector2(moveH, moveV);

        playerRig.velocity = move * speed;
    }

  


    
}
