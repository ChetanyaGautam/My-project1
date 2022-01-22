using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    bool Running = false;
    bool Isjumping = false;


    private void Awake()
    {
        Debug.Log("Player Controller Awake");
    }
    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         Debug.Log("Collision : " + collision.gameObject.name);
     }*/
   

    public void Update()
    {

        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;



        float jump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Jump", Mathf.Abs(jump));

        Vector3 localscale = transform.localScale;
        if (jump < 0)
        {
            scale.y = -1f * Mathf.Abs(scale.y);
        }

        Running = Input.GetKey(KeyCode.LeftShift);
        Isjumping = Input.GetKey(KeyCode.LeftControl);
            

            animator.SetBool("Bool", Running);
            animator.SetBool("Bool2", Isjumping);
           
        

    }
    

}
