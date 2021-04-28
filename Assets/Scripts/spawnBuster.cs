using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBester : MonoBehaviour
{
    public GameObject[] busters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        print("Work!");
        SpawnBuster();
    }

    void SpawnBuster()
    {
        int spawnTrigger = Random.Range(0, 100);

        if(spawnTrigger > 80)
        {
            Instantiate(busters[Random.Range(0, busters.Length - 1)], transform.position, transform.rotation);
        }
    }
}
