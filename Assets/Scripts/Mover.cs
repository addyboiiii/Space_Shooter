using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float speed;
    private void Start()
    {
        Rigidbody current_obj = gameObject.GetComponent<Rigidbody>();
        current_obj.velocity = current_obj.transform.forward * speed;
    }
}
