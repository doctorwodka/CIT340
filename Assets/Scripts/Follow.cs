using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject objectToFollow;
    public float lerpPerFrame = 0.1f;
    public bool lockYAxis = false;
    // Update is called once per frame



    void Update()
    {
        
        
        Vector3 objPos = objectToFollow.transform.position;

        objPos.z = transform.position.z;
        if (lockYAxis)
        {
            objPos.y = transform.position.y;

        }

        transform.position = Vector3.Lerp(transform.position, objPos, lerpPerFrame);
    }
}
