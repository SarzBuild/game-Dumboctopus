using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Platform : MonoBehaviour
{
    float moveDistance = 5.0f;
    void Start()
    {
        if (!gameObject.CompareTag("MovingPlatform"))
        {
            Destroy(this.gameObject, 3);
        }
        
    }

    void Update()
    {
        
    }
}
