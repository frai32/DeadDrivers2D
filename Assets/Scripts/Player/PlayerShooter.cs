using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bolt;
    public GameObject shotSpawn;
    public float fireRate;
    float nextFire;
    bool haveDoubleShots = false;
    int count = 50;

    public void setHaveBuster (bool HB)
    {
        haveDoubleShots = HB;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (haveDoubleShots)
            doubleShooting();
        else
            shoting();
    }

    void shoting()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, shotSpawn.transform.position, shotSpawn.transform.rotation);

        }
    }

    void doubleShooting()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, new Vector3(shotSpawn.transform.position.x - 0.2f, shotSpawn.transform.position.y , 0), shotSpawn.transform.rotation);
            Instantiate(bolt, new Vector3(shotSpawn.transform.position.x + 0.2f, shotSpawn.transform.position.y , 0), shotSpawn.transform.rotation);

            count--;
        }

        if(count<=0)
        {
            count = 50;
            haveDoubleShots = false;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().doubleText.gameObject.SetActive(false);
        }
    }
}
