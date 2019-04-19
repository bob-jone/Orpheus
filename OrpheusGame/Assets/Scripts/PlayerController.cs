using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
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
            jumpCount = 0;
        }
    }

    void Update()
    {
        t = Globals.tempo / 80;

        velocity.x = moveSpeed * t;
        velocity.y += ((gravity * -1) * Time.deltaTime);

        if (mathM.collisions.above || mathM.collisions.below)
        {
            velocity.y = 0;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (transform.position.y < -20)
        {

        }

        CheckGrounded();

        mathM.Move(velocity);

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("isGrounded: " + isGrounded);
            Debug.Log("jumpCount: " + jumpCount);
        }
    }
}
