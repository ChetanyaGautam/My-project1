using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    bool Running = false;
    bool Crouch = false;
    public float speed;
    public float jump;
   
    private Rigidbody2D Rgd2D;


    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        Rgd2D = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprites = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float speed1 = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        MoveCharacter(speed1, vertical);
        PlayMovementAnimation(speed1, vertical);
    }
    private void MoveCharacter(float speed1 , float vertical) 
    {

        /* move Horizontally*/
        Vector3 position = transform.position;
        position.x += speed1 * speed * Time.deltaTime;
        transform.position = position;


        if (vertical > 0)
        {
            Rgd2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }





    }


    private void PlayMovementAnimation(float speed1, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(speed1));

        Vector3 scale = transform.localScale;
        if (speed1 < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        } 
        else if (speed1 > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;  

         /*jumpping*/
        if (vertical > 0)
        {
            animator.SetBool ("Jump", true);
           
        }else
        {
            animator.SetBool("Jump", false);
        }
      




        Vector3 localscale = transform.localScale;
        
       
            Running = Input.GetKey(KeyCode.LeftShift);
            Crouch = Input.GetKey(KeyCode.LeftControl);
            animator.SetBool("Bool", Running);
            animator.SetBool("Bool2", Crouch);
    }
}
