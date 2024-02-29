using UnityEngine;

public class antAI : MonoBehaviour
{
    private Vector3 vel;
    private Vector3 pos;
    private Vector3 direction;
    private Vector3 target;
    public float detectionRange = 10f;
    public float Vmax = 5.5f;
    Quaternion rotangle;
    public float jumpForce = 10f;
    private bool shouldMove = false;
    private bool canjump = false;

    // Start is called before the first frame update
    void Start()
    {
        vel = Vector3.zero;
        SetRandomTarget();
        canjump = true;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();

        if (shouldMove)
        {
            runrandomly();
        }
    }

    void runrandomly()
    {
        float deltaTime = Time.fixedDeltaTime;

        direction = target - pos;
        vel = direction.normalized * Vmax;

        float betaDeg = Mathf.Atan(direction.x) * Mathf.Rad2Deg;
        rotangle = Quaternion.AngleAxis(betaDeg, new Vector3(0, -1, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotangle, Time.deltaTime * 8f);

        pos += vel * deltaTime;
        transform.position = pos;

        // Check if the ant reached the target, then set a new random target
        if (Vector3.Distance(pos, target) < 0.1f)
        {
            SetRandomTarget();
        }
    }

    void SetRandomTarget()
    {
        float randomOffsetX = Random.Range(-15f, 15f) + 5f;
        float randomOffsetY = 0; // Adjust the range based on your desired Y offset
        float randomOffsetZ = Random.Range(-15f, 15f) + 5f;

        target = pos + new Vector3(randomOffsetX, randomOffsetY, randomOffsetZ);
        target = new Vector3(target.x, transform.position.y, target.z);
    }
    void JumpTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = player.transform.position - transform.position;
            direction.y += 5f;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            // Set the velocity to make the GameObject jump towards the player
            GetComponent<Rigidbody>().velocity = direction * jumpForce;
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure the player object has the 'Player' tag.");
        }
    }
    void DetectPlayer()
    {
        // Cast a sphere forward to detect the player
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, detectionRange, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (canjump)
                {
                    JumpTowardsPlayer();
                    canjump = false;
                }

                shouldMove = true; // Set the flag to allow movement when the player is detected
            }
        }
    }
}