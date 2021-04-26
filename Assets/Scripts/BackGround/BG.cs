using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public float speed= 0.1f;
    private Vector2 offset = Vector2.zero;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        offset = material.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += speed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
