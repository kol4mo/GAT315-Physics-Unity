using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour {
    [SerializeField] Vector3 force;
    [SerializeField] ForceMode mode;

    [SerializeField] Vector3 torque;
    [SerializeField] ForceMode torqueMode;

    [SerializeField] KeyCode jumpKey;
    [SerializeField] float jumpPower = 10;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKeyDown(jumpKey)) {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(force, mode);
            rb.AddTorque(torque, torqueMode);
        }
    }
}
