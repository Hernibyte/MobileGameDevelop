using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rig.velocity = transform.up * speed;
    }
}
