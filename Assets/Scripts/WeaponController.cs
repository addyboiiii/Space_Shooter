using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    GameObject shot;

    [SerializeField]
    Transform shot_spawn;

    [SerializeField]
    float fire_rate, delay;

    void Start()
    {
        InvokeRepeating("Fire", delay, fire_rate);
    }
    void Fire()
    {
        Instantiate(shot, shot_spawn.position, shot_spawn.rotation);
    }
}
