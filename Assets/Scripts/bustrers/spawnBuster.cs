using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBuster : MonoBehaviour
{
    public GameObject[] busters;
    public int healthOfObject;
    private Tags t;
    // Start is called before the first frame update
    void Start()
    {
        t = new Tags();
    }

    // Update is called once per frame
    void Update()
    {
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(t.getTagList[(int)ETags.BAUNDARY_TAG]))
            return;
         
        if (collision.CompareTag(t.getTagList[(int)ETags.PLAYER_TAG]))
            healthOfObject -= healthOfObject;
        else if(collision.CompareTag(t.getTagList[(int)ETags.BOLT_TAG]))
            healthOfObject--;
        

        if (healthOfObject<=0)
            SpawnBuster();


    }

    void SpawnBuster()
    {
        int spawnTrigger = Random.Range(0, 100);

        if(spawnTrigger > 80)
        {
            Instantiate(busters[Random.Range(0, busters.Length)], transform.position, transform.rotation);
        }
    }

   
}
