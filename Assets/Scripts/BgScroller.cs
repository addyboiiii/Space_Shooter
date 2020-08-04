using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroller : MonoBehaviour
{
    [SerializeField]
    float scroll_speed, tile_sizeZ;

    Vector3 start_position;
    private void Start()
    {
        start_position = gameObject.transform.position;
    }
    private void Update()
    {
        float new_position = Mathf.Repeat(Time.time * scroll_speed, tile_sizeZ);
        gameObject.transform.position = start_position + Vector3.forward * new_position;
    }
}
