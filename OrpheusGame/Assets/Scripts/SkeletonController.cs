using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    private Animator anim;
    public bool isDead = false;
    public float moveSpeed;
    public float flipPercentage = 10f;

    public bool facingRight = true;
    Rigidbody2D rb;
    [SerializeField]
    float flipCooldown = 0.5f;
    float flipTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
    void RandomlyFlip()
    {
        if (flipPercentage >= Random.Range(1, 100))
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * moveSpeed * Time.deltaTime, rb.velocity.y);

        flipTimer += Time.deltaTime;
        if (flipTimer >= flipCooldown)
        {
            RandomlyFlip();
            flipTimer = 0f;
        }
    }
}
