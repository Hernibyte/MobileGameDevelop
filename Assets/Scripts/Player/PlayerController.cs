using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    private Rigidbody rig;
    public Joystick JoyStick1;
    public Boundary boundary;
    public float velocidad = 2f;

    [Header("Shoting")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.localPosition += Time.deltaTime * new Vector3(JoyStick1.Horizontal, JoyStick1.Vertical, 0) * velocidad;
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
