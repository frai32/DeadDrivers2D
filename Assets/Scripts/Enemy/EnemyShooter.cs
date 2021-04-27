using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float speed;
    public Transform player;
    public GameObject bullet;

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
        
        if (TimeBTWShots <=0)
        {
         var direction = transform.position - player.transform.position;
            //direction.x = 0;
            //direction.z = direction.y;
            //direction.y = 0;// тут указать 0 для той оси, которую не надо изменять*/
            //Instantiate(bullet, transform.position, bullet.transform.rotation);

          Instantiate(bullet, transform.position, Quaternion.LookRotation((direction).normalized));
            TimeBTWShots = startTimeBTWShots;
        }
        else
        {
            TimeBTWShots -= Time.deltaTime;
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
