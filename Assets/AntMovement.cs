using UnityEngine;

public class AntMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Normalize movement vector and adjust speed
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Move the ant
        transform.Translate(movement);

        // Set IsWalking parameter in the animator
        if (movement.magnitude > 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
