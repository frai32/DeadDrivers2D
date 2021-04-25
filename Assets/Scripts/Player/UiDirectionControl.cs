using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDirectionControl : MonoBehaviour
{
    public bool UseRelativeRotation = true;
    private Quaternion relationRotation;
    // Start is called before the first frame update
    void Start()
    {
        relationRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (UseRelativeRotation)
            transform.rotation = relationRotation;
    }
}
