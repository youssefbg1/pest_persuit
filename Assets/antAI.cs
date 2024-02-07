using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antAI : MonoBehaviour
{
    private Vector2 vel;
    private Vector2 pos;
    private Vector2 direction;
    private Vector2 target;
    public float Vmax = 5.5f;
    Quaternion rotangle;

    // Start is called before the first frame update
    void Start()
    {
        vel = Vector2.zero;
        SetRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        runrandomly();
    }

    void runrandomly()
    {
        float deltaTime = Time.fixedDeltaTime;

        direction = target - pos;
        vel = direction.normalized * Vmax;

        float betaDeg = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotangle = Quaternion.AngleAxis(betaDeg, new Vector3(0, 0, 1));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotangle, Time.deltaTime * 8f);

        pos += vel * deltaTime;
        transform.position = pos;

        // Check if the ant reached the target, then set a new random target
        if (Vector2.Distance(pos, target) < 0.1f)
        {
            SetRandomTarget();
        }
    }

    void SetRandomTarget()
    {
        float randomOffsetX = Random.Range(-15f, 15f); // Adjust the range based on your desired offset
        float randomOffsetZ = Random.Range(-15f, 15f); // Adjust the range based on your desired offset

        target = pos + new Vector2(randomOffsetX, randomOffsetZ);
    }
}
