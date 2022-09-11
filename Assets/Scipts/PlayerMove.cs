using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    public static bool isFacingRight = true;
    public Animator walk_jump;
    public Weapon weapon;
    Vector2 moveDirection;
    public int coinValue;
    public static int lastScene;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown("return")){
            SoundScript.PlaySound("laser_bullet");
            weapon.Fire();
        }

        walk_jump.SetFloat("Movement", Mathf.Abs(horizontal));

        if (Input.GetKeyDown("space") && isGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 15f);
            walk_jump.SetBool("is_Jump", true);
        }

        if (Input.GetKeyUp("space") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            walk_jump.SetBool("is_Jump", false);
        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Elevator"){
            transform.parent = collision.gameObject.transform;
        }

        if (collision.gameObject.tag == "Enemy"){
            lastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Elevator"){
            transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Coins"){
            ScoreManager.instance.ChangeScore(coinValue);
            SoundScript.PlaySound("coin");
            collider.GetComponent<ParticleSystem>().Play();
            collider.GetComponent<SpriteRenderer>().enabled = false;
            collider.GetComponent<CapsuleCollider2D>().enabled = false;
        }
        
        if(collider.gameObject.tag == "PowerUp"){
            StartCoroutine(NoSpeed(3.0f));
            Destroy(collider.gameObject);
        }
    }

    IEnumerator NoSpeed(float timeOut){
        speed += 10;
        yield return new WaitForSeconds(timeOut);
        speed -= 10;
    }
}