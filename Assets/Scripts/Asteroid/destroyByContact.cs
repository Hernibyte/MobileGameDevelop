using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boundary") return;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}