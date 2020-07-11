using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z) + offset;
    }
}
