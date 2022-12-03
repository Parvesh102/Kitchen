using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference to the Animator component of the player
    public Animator anim;

    

    private void Start()
    {
       
    }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
    {
        var velocity = Vector3.forward*Input.GetAxis("Vertical") * 5f;
       
        anim.SetFloat("anim", velocity.magnitude);
       
    }
}
