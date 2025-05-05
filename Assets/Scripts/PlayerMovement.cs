using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private BoxCollider2D coll;
    float dirX=0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField]private float jumpp = 10f;
    [SerializeField] private LayerMask jumpableGround;
    public enum MovementsState {idle,running,jumping ,falling}
  
    
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

  
   private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed,rb.velocity.y);

        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpp);
        }
        UpdateAnimation();
       
    }
    private void UpdateAnimation()
    {
        MovementsState state;
        
        if (dirX > 0f)
        {
            state = MovementsState.running;
            sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementsState.running;
            sp.flipX = true;       
        }
        else
        {
            state = MovementsState.idle;
        }
        if (rb.velocity.y>.1f)
        {
            state = MovementsState.jumping;
        }
        else if (rb.velocity.y<-.1f)
        {
            state = MovementsState.falling;
        }
        anim.SetInteger("state",(int)state);
    }
 


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
        //boxcast-> coll.bounds.center: kutunun merkez noktasý, coll.bounds.size:kutunun boyut, 0f döndürme açýsý
        //Vector2down aþaðý doðru ýþýn kýlýcý ,.1f kutunun altýna, jumpableGround true -> yerdedir.
    }
}
