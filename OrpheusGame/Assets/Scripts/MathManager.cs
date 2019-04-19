using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(CapsuleCollider2D))]

public class MathManager : MonoBehaviour
{
    PlayerController player;
    public LayerMask collisionMask;
    // for gravity calculations
    public bool isGrounded;

    // ray calculations
    // skin offset

    const float skinWidth = .015f;
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;
    float horizontalRaySpacing;
    float verticalRaySpacing;

    CapsuleCollider2D collide;
    RaycastOrigins raycastOrigins;

    public CollisionInfo collisions;

    void CalculateRaySpacing()
    {
        Bounds bounds = collide.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    // names for classes in program and outside of program shorthand
    // Use this for initialization
    void Start()
    {

        player = GetComponent<PlayerController>();
        collide = GetComponent<CapsuleCollider2D>();

        CalculateRaySpacing();
    }

    public void Move(Vector3 velocity)
    {
        collisions.Reset();
        UpdateRaycastOrigins();

        if (velocity.x != 0)
        {
            horizontalCollisions(ref velocity);
        }
        if (velocity.y != 0)
        {
            verticalCollisions(ref velocity);
        }


        transform.Translate(velocity);
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = collide.bounds;
        bounds.Expand(skinWidth * -2);
        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    void verticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;


        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
            
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);
            Debug.DrawRay(rayOrigin, Vector2.up * directionY, Color.red);
            if (hit)
            {
                collisions.collidedObject = hit.collider.gameObject;
                velocity.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;
                isGrounded = true;
                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
            }
        }
    }

    void horizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLength = Math.Abs(velocity.x) + skinWidth;

        for (int j = 0; j < horizontalRayCount; j++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * j);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            if (hit)
            {
                collisions.collidedObject = hit.collider.gameObject;
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;
                collisions.left = directionX == -1;
                collisions.right = directionX == 1;
            }
        }
    }

    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;
        public GameObject collidedObject;
        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }
}