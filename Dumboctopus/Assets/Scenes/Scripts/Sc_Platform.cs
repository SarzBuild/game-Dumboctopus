using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Platform : MonoBehaviour
{
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
