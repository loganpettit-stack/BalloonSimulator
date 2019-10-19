using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope_charmer : MonoBehaviour
{
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.inertiaTensor = new Vector3(1.0f, 2.0f, 3.0f);
        rb.inertiaTensorRotation = new Quaternion(0.1f, 0.1f, 0.1f, 0.1f);
    }
}
