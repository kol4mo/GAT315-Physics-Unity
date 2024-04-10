using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifespan = 0;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        if (lifespan > 0) Destroy(gameObject, lifespan);
        rb = GetComponent<Rigidbody>();

        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
