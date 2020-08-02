using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Boundary boundary;

    [SerializeField]
    float tilt;

    private void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Rigidbody current_obj = gameObject.GetComponent<Rigidbody>();
        current_obj.velocity = new Vector3(move_horizontal, 0.0f, move_vertical) * speed;
        current_obj.position = new Vector3(
            Mathf.Clamp(current_obj.position.x, boundary.x_min, boundary.x_max),
            0.0f,
            Mathf.Clamp(current_obj.position.z, boundary.z_min, boundary.z_max)
            );
        current_obj.rotation = Quaternion.Euler(0, 0, current_obj.velocity.x * -tilt);
    }
}
