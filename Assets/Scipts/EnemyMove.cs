using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public static double HP = 1;
    private bool isFacingRight = true;
    private float movementDirection = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate(){
        if (CheckForGround() == true) {
            rb.velocity = new Vector2(movementDirection, 0f);
            }
        
        if (CheckForGround() == false) {
            rb.velocity = new Vector2((movementDirection * -1f), 0f);
            
            ChangeDirection();
        }
    }

    private bool CheckForGround(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private void ChangeDirection(){
            isFacingRight = !isFacingRight;
            movementDirection *= -1f;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag == "Weapon"){
            HP -= 0.33;

            if(HP <= 0.01){
             SoundScript.PlaySound("enemy_death");
             Destroy(gameObject);
            }
        }
    }
}
