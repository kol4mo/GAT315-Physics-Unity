using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour {
    [SerializeField] Vector3 force;
    [SerializeField] ForceMode mode;

    [SerializeField] Vector3 torque;
    [SerializeField] ForceMode torqueMode;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(force, mode);
            rb.AddTorque(torque, torqueMode);
        }
    }
}
