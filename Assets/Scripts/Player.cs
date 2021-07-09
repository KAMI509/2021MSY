using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    private Vector2 up;
    private float h;
    SpriteRenderer spriteRenderer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxisRaw("Horizontal");
        up = new Vector2(h,0);
        transform.Translate(up*Time.deltaTime*speed);

        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up*300f);
            animator.SetTrigger("isJump");
           //transform.position= new Vector3(10,10,0);
        }
        if(Input.GetAxisRaw("Horizontal")<0){
            //spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1,1,1);
            animator.SetBool("isRun",true);
        }
        else if(Input.GetAxisRaw("Horizontal")>0){
            transform.localScale = new Vector3(1,1,1);
            animator.SetBool("isRun",true);
        }
        else if(Input.GetAxisRaw("Horizontal")==0){
            animator.SetBool("isRun",false);
        }



    }
}
