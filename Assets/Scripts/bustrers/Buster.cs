using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buster : MonoBehaviour
{
    private static GameController localControl;

    public GameController getLocalControl()
    {
        
        return localControl;
    }
    private void Start()
    {
        checkGameControll();
    }

    public void checkGameControll()
    {
        GameObject gameControll = GameObject.FindGameObjectWithTag("GameController");
        if (gameControll != null)
        {
            localControl = gameControll.GetComponent<GameController>();
        }

        if (gameControll == null)
        {
            Debug.LogError("GameController is missed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
