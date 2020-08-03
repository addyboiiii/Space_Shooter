using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    float life_time;
    void Start()
    {
        Destroy(gameObject, life_time);
    }
}
