
using UnityEngine;

public class player_movement : MonoBehaviour
{     
    
    
    
    //oogga booga



    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField]  private LayerMask groundlayer;
    [SerializeField] private LayerMask walllayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float walljumpcooldown;
    private float horizontalinput;
    private void Awake()
    {
        //grab reff 



        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
         horizontalinput = Input.GetAxis("Horizontal");
       


        //flip player position when mmoving left/right



        if (horizontalinput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(-1,1, 1);

        //set anim param


        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("grounded", isgrounded());


        //wall JUMPPPPP


        if (walljumpcooldown > 0.2f)
        {
            

            body.velocity = new Vector2(horizontalinput * speed, body.velocity.y);
            if (onWall() && !isgrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else 
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                jump();
        }
        else
            walljumpcooldown += Time.deltaTime;
    }

    //jump 


    private void jump()
    {
        if (isgrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
       else if (onWall() && !isgrounded())
        {
            if(horizontalinput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y,transform.localScale.z );
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            walljumpcooldown = 0;
            
        }
        
    }

   
    //dedects walls/ground w/ ray



    private bool isgrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
            return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, walllayer);
        return raycastHit.collider != null;
    }
    //attack
    public bool canattak()
    {
        return horizontalinput == 0 && isgrounded() && !onWall();
    }
}
