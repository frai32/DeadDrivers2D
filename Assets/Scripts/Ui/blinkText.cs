using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinkText : MonoBehaviour
{
    Text blinkingText;
    bool isActive = true;
    string textOfString;


    private void Awake()
    {
        blinkingText = GetComponent<Text>();
        textOfString = blinkingText.text;
      
        StartCoroutine(blinking());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator blinking()
    {
        yield return new WaitForSeconds(1);
        Blink();
    }

    void Blink()
    {
        if (isActive)
        {
            blinkingText.text = "";
            isActive = false;
        }
        else
        {
            blinkingText.text = textOfString;
            isActive = true;
        }
        StartCoroutine(blinking());
    }
}
