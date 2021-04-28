using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMover : MonoBehaviour
{
    public float speed;
    private Transform point;
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void setTarget(Transform newTarget)
    {
        point = newTarget;

        target = new Vector3(point.position.x, point.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        /*if (transform.position.x == target.x && transform.position.y == target.y)
        {
            
        }*/
        // transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    


}
