using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class block : MonoBehaviour
{
    [SerializeField] int points = 100;
    [SerializeField] AudioSource audioSource;
    [SerializeField] IntVariable score;

    Rigidbody rb;
    bool destroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2) {
            audioSource.Play();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (!destroyed && other.CompareTag("kill") && 
            rb.velocity.magnitude == 0 && 
            rb.angularVelocity.magnitude == 0) {
            destroyed = true;
            score.value += points;
            Destroy(gameObject, 2);
        }
    }
}
