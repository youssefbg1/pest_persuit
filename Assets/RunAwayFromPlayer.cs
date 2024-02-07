using UnityEngine;

public class RunAwayFromPlayer : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float raycastDistance = 10f; // Maximum distance to cast the ray
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
            // Calculate the direction from the object to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Raycast to check if the player's line of sight intersects with the object
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Player is aiming at the object, start running away
                    isRunning = true;
                }
                else
                {
                    // Player is not aiming at the object
                    isRunning = false;
                }
            }

            // Run away from the player if isRunning is true
            if (isRunning)
            {
                // Calculate the opposite direction to run away from the player
                Vector3 oppositeDirection = -directionToPlayer.normalized;
                transform.position += oppositeDirection * moveSpeed * Time.deltaTime;
            }
        }
    }
}
