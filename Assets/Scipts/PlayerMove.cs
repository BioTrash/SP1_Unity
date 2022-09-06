using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    public static bool isFacingRight = true;
    public Animator walk_jump;
    public Weapon weapon;
    Vector2 moveDirection;
    Vector2 mousePosition;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown("return")){
            weapon.Fire();
        }

        walk_jump.SetFloat("Movement", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && isGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 15f);
            walk_jump.SetBool("is_Jump", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            walk_jump.SetBool("is_Jump", false);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * 10f, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Elevator"){
            transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Elevator"){
            transform.parent = null;
        }
    }
}