using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // variables
    public Rigidbody2D rb;
    public float moveSpeed;
    public float speedX, speedY;
    private Vector2 _moveDirection;
    public InputActionReference move;
    private bool facingLeft = true;
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();

        // store directional movement variables
        if (_moveDirection.x > 0 && facingLeft || _moveDirection.x < 0 && !facingLeft)
        {
            FlipSprite();
        }


    }

    // flips direction of player sprite to match direction
    public void FlipSprite()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }
}
