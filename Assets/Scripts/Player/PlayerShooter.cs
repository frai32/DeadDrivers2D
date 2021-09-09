using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bolt;
    public GameObject shotSpawn;
    public float fireRate;
    public int PlayerNumber;

    float nextFire;
    bool haveDoubleShots = false;
    int count = 50;
    Tags t; 
   
    public void setHaveBuster (bool HB)
    {
        haveDoubleShots = HB;
    }
    
    // Start is called before the first frame update
    
    void Start()
    {
        t = new Tags();  
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
        if (Input.GetButton("Fire" + PlayerNumber) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, shotSpawn.transform.position, shotSpawn.transform.rotation);

        }
    }

    void doubleShooting()
    {
        if (Input.GetButton("Fire"+ PlayerNumber) && Time.time > nextFire )
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

            GameObject.FindGameObjectWithTag(t.getTagList[(int)ETags.GAME_CONTROLLER_TAG]).GetComponent<GameController>().doubleText.gameObject.SetActive(false);
        }
    }
}
