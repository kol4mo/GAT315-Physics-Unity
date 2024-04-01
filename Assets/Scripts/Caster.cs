using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour {
    public enum etype {
        Ray,
        Sphere,
        Box
    }

    [SerializeField] etype type = etype.Ray;
    [SerializeField] float size = 1.0f;
    [SerializeField] float distance = 2;
    [SerializeField] LayerMask mask = -1;

    RaycastHit[] hits;

    void Update() {
        switch (type) {
            case etype.Ray:
                hits = Physics.RaycastAll(transform.position, transform.forward, distance, mask);
                break;
            case etype.Sphere:
                hits = Physics.SphereCastAll(transform.position, size * 0.5f, transform.forward, distance, mask);
                break;
            case etype.Box:
                hits = Physics.BoxCastAll(transform.position, Vector3.one * size * 0.5f, transform.forward, transform.rotation, distance, mask);
                break;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        switch (type) {
            case etype.Ray:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                break;
            case etype.Sphere:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                Gizmos.DrawWireSphere(transform.position + Vector3.forward * distance, size * 0.5f);
                break;
            case etype.Box:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                Gizmos.DrawWireCube(transform.position + Vector3.forward * distance, Vector3.one * size);
                break;
        }
        

        if (hits != null) {
            Gizmos.color = Color.red;
            foreach (RaycastHit hit in hits) {
                Gizmos.DrawWireCube(hit.collider.transform.position, hit.collider.bounds.size);
            }
        }
    }
}
