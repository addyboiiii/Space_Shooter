using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    [SerializeField]
    Vector2 start_wait, maneuver_time, maneuver_wait;

    [SerializeField]
    float dodge, smoothing, tilt;

    [SerializeField]
    Boundary boundary;

    float target_maneuver, current_speed;
    Rigidbody rb;

    private void FixedUpdate()
    {
        float new_maneuver = Mathf.MoveTowards(rb.velocity.x, target_maneuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(new_maneuver, 0.0f, current_speed);
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.x_min, boundary.x_max),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.z_min, boundary.z_max)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    private void Start()
    {
        StartCoroutine(Evade());
        rb = GetComponent<Rigidbody>();
        current_speed = rb.velocity.z;
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(start_wait.x, start_wait.y));
        while (true)
        {
            target_maneuver = Random.Range(1, dodge) * - Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuver_time.x, maneuver_time.y));
            target_maneuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuver_wait.x, maneuver_wait.y));
        }
    }
}
