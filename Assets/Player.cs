using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{


public float geschwindichkeit = 0.1f;
public float springen =10f;
Rigidbody2D rigidbody;
public LayerMask layerMask;
int jumps = 1;
Animator animatior;
SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animatior = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update() {
        RightLeftWalk();
        Jump();
        CheckJumps();

        if (Input.GetKey(KeyCode.RightArrow)) {
            sr.flipX = false;
            animatior.Play("walk");
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            sr.flipX = true;
            animatior.Play("walk");
        } else if (!animatior.GetCurrentAnimatorStateInfo(0).IsName("punch")) {
            animatior.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            animatior.Play("punch");
        }
    }
    // Update is called once per frame
    void RightLeftWalk()
        {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(Vector2.right * geschwindichkeit, ForceMode2D.Force);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) 
        {
          rigidbody.AddForce(Vector2.left * geschwindichkeit, ForceMode2D.Force);
        }

        if (rigidbody.velocity.x > 5) 
        {
           rigidbody.velocity = new Vector2(5, rigidbody.velocity.y);
        }
        else if (rigidbody.velocity.x < -5) {
           rigidbody.velocity = new Vector2(-5, rigidbody.velocity.y);
        }
        }     
       void Jump()
       {
        if(Input.GetKeyDown(KeyCode.Space) && jumps > 0)
            {
            jumps--;
            rigidbody.AddForce(Vector2.up *  springen, ForceMode2D.Impulse);
            }
        }
       void OnTriggerEnter2D(Collider2D other){

           Rigidbody2D rigidbody = GetComponent <Rigidbody2D>();
            rigidbody.AddForce(other.transform.up *  springen, ForceMode2D.Impulse);
        
        }
        void CheckJumps() {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down, 1.8f, layerMask);
            if (hit.collider != null && rigidbody.velocity.y <= 0) {
                jumps = 1;
            }
}
}