using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0;

    public static PlayerMovement playerMovementInstance;

    Animator animator;

    Vector2 movement = new Vector2();

    Rigidbody2D rb2D;

    string lastMoveX = "lastMoveX", lastMoveY = "lastMoveY", isWalking = "isWalking",
           xDir = "xDir", yDir = "yDir";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovingAnimation();
    }

    private void FixedUpdate()
    {
    }

    public void moveCharacter(bool canWalk)
    {

       if (canWalk == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            movement.Normalize();

            rb2D.velocity = movement * movementSpeed;

        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    void UpdateMovingAnimation()
    {
        if (Mathf.Approximately(movement.x, 0) && Mathf.Approximately(movement.y, 0))
        {
            animator.SetBool(isWalking, false);
        }
        else
        {
            animator.SetBool(isWalking, true);
        }

        animator.SetFloat(xDir, movement.x);
        animator.SetFloat(yDir, movement.y);

        if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            animator.SetFloat(lastMoveX, movement.x);
            animator.SetFloat(lastMoveY, movement.y);
        }
    }
    
}
