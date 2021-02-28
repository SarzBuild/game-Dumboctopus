using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_GroundChecker : MonoBehaviour
{
    public bool isGrounded;

    public void OnCollisionStay2D(Collision2D collidedWith)
    {
        if (collidedWith.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    public void OnCollisionExit2D(Collision2D collidedWith)
    {
        if (collidedWith.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
