using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShooters : MonoBehaviour
{
    public Transform targetToStart;
    public GameObject spawnObject;
    
  

    public float spawnWait;
  
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( spawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(spawnWait);
       
        Vector2 spawnPosition = targetToStart.transform.position;

        GameObject newObj = Instantiate(spawnObject, spawnPosition, Quaternion.identity);
        newObj.GetComponent<enemyMover>().setTarget(gameObject.transform);
        newObj.GetComponent<blinkScript>().setParent(this);

    }

    

    public void Repeat()
    {
       StartCoroutine(spawnWaves());
    }


  
}
