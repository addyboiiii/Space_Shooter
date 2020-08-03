using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    float tumble;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
