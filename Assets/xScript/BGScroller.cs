using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollerSpeed = 0; //????
    public float tilesSizeZ = 0;
    private Vector3 startPosition = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollerSpeed,tilesSizeZ);
        gameObject.GetComponent<Transform>().position
             = startPosition + Vector3.forward * newPosition;
    }
}
