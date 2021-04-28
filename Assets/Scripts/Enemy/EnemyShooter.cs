using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float speed;
    public Transform player;
    public GameObject bullet;
    public GameObject spawn;

    private float TimeBTWShots;
    public float startTimeBTWShots;
    Rigidbody2D rig;
    float rotateSpeed = 200;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TimeBTWShots = startTimeBTWShots;
        rig = GetComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
    }

    void Shoot()
    {
        if(player != null)
        {
            if (TimeBTWShots <= 0)
            {

                Instantiate(bullet, spawn.transform.position, spawn.transform.rotation);
                TimeBTWShots = startTimeBTWShots;
            }
            else
            {
                TimeBTWShots -= Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 dirTur = (Vector2)player.position - rig.position;
        dirTur.Normalize();
        float rotateAmount = Vector3.Cross(dirTur, transform.up).z;
        rig.angularVelocity = -rotateAmount * rotateSpeed;
    }
}
