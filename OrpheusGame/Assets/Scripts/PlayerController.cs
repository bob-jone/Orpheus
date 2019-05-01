using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Text text;
    public Vector3 jump;
    public float timeToJumpApex;
    public float gravity;
    public float dashDownVelocity;
    Vector3 velocity;
    public float jumpVelocity;
    public float moveSpeed;
    public float t;

    public bool isGrounded;
    public int jumpCount;

    public Collider2D playerCollider;
    public LayerMask ground;
    public Animator anim;
    float initX;
    MathManager mathM;
    float initY;

    // Start is called before the first frame update
    void Start()
    {
        initX = transform.position.x;
        initY = transform.position.y;
        t = Globals.tempo/80;
        mathM = GetComponent <MathManager>();
        jumpVelocity = gravity * timeToJumpApex;
        anim = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
        anim.SetBool("isWalking", true);
    }
    public void Jump()
    {
        if (isGrounded || jumpCount < 2)
        {
            velocity.y = jumpVelocity;
            jumpCount++;

            anim.SetBool("jump", true);
        }
    }
    public void DashDown()
    {
        velocity.y = dashDownVelocity;
    }

    private void CheckGrounded()
    {
        isGrounded = mathM.collisions.below;
        if (isGrounded)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("jump", false);
            jumpCount = 0;
        }
    }

    void Update()
    {
        t = Globals.tempo / 80;

        velocity.x = moveSpeed * t;
        velocity.y += ((gravity * -1) * Time.deltaTime);

        if (mathM.collisions.below)
        {
            velocity.y = 0;
        }
        if (mathM.collisions.right|| mathM.collisions.right|| mathM.collisions.below|| mathM.collisions.above)
        {
            if (mathM.collisions.collidedObject.tag.Equals("Item"))
            {
                Globals.tempo += 10;
                Destroy(mathM.collisions.collidedObject);
            }
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (transform.position.y < -20)
        {
            Globals.globalScore = (int)((transform.position.x - 6) / 10);
            SceneManager.LoadScene("ENDSCREEN");
            
        }

        CheckGrounded();

        mathM.Move(velocity);

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("isGrounded: " + isGrounded);
            Debug.Log("jumpCount: " + jumpCount);
        }
        text.text = ((int)((transform.position.x-6)/10)).ToString();
    }
}
