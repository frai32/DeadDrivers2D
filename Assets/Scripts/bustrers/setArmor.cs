using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setArmor : Buster
{
   

    private void Start()
    {
        checkGameControll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           collision.GetComponent<health>().setArmor(true);
            getLocalControl().armorText.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
