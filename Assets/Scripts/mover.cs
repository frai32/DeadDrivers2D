using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    Rigidbody2D boltRig;
    public float Speed;
    private void Start()
    {
        boltRig = GetComponent<Rigidbody2D>();

        setSpeed(Speed);
        if (Speed < 0)
            GetComponent<SpriteRenderer>().flipY = true;
    }

    public void setSpeed(float speed)
    {
        boltRig.velocity = transform.up * speed;
    }
}
