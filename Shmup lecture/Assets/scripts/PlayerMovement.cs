using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f, JumpHeight = 5f;
    public Rigidbody2D RB;
    public BoxCollider2D PlayerCollider;
    public LayerMask GroundLayer;
    public SpriteRenderer PlayerSprite;
    public bool IsFacingRight = true;
    public bool Slamming = false;
    public bool IsGrounded;

    private void Start()
    {
        GroundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        Move();
    }

    private void Move() 
    {
        Keyboard k = Keyboard.current;

        if (k == null)
            return;

        GroundCheck();

        if (k.spaceKey.wasPressedThisFrame)
            Jump();
        if (k.sKey.wasPressedThisFrame)
            Slam();

        float x = (k.dKey.isPressed ? 1 : 0) - (k.aKey.isPressed ? 1 : 0);
        float move = MoveSpeed * x;

        RB.linearVelocityX = move;

        Turn(move);

    }

    private void Jump() 
    {
        if (IsGrounded) 
        {
            RB.AddForceY(JumpHeight, ForceMode2D.Impulse);
        }
    }

    private void Turn(float move)
    {
        if (move == 0)
            return;

        if (move > 0 && !IsFacingRight) 
        {
            IsFacingRight = true;
            PlayerSprite.flipX = false;
        }
        else if (move < 0 && IsFacingRight)
        {
            IsFacingRight = false;
            PlayerSprite.flipX = true;
        }
    }

    private void Slam() 
    {
        if(!IsGrounded)
        {
            Slamming = true;
            RB.AddForceY(-JumpHeight, ForceMode2D.Impulse);
        }
    }

    private void GroundCheck()
    {
        if(PlayerCollider.IsTouchingLayers(GroundLayer))
        {
            IsGrounded = true;
            Slamming = false;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
