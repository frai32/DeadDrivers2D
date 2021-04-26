using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleShots : Buster
{ 

    private void Start()
    {
        checkGameControll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerShooter>().setHaveBuster(true);
            getLocalControl().doubleText.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
