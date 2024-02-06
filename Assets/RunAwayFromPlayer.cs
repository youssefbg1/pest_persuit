using UnityEngine;

public class RunAwayFromPlayer : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float runningRadius = 5f; // The radius within which the object starts running
    private Transform player;
    private bool isRunning = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = transform.position - player.position;
            float distanceToPlayer = directionToPlayer.magnitude;

            // Check if the player is within the running radius
            if (distanceToPlayer < runningRadius)
            {
                // Player is within the running radius, start running away from the player
                isRunning = true;
            }

            // Run away from the player if isRunning is true
            if (isRunning)
            {
                directionToPlayer.Normalize();
                transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
            }
        }
    }
}
