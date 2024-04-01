using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlap : MonoBehaviour {
    public enum OverlapType {
        BoundingBox,
        Sphere
    }

    [SerializeField] OverlapType type = OverlapType.BoundingBox;
    [SerializeField] float size = 1;
    [SerializeField] LayerMask layerMask = Physics.AllLayers; //-1 means all layers

    Collider[] colliders;

    void Update() {
        switch (type) {
            case OverlapType.BoundingBox:
                colliders = Physics.OverlapBox(transform.position, Vector3.one * (size * 0.5f), transform.rotation, layerMask);
                break;
            case OverlapType.Sphere:
                colliders = Physics.OverlapSphere(transform.position, size * 0.5f, layerMask);
                break;
        }

        if (Input.GetKey(KeyCode.Space)) {
            Physics.gravity = new Vector3(0, 10, 0);
        } else {
            Physics.gravity = new Vector3(0,-9.8f, 0);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        switch (type) {
            case OverlapType.BoundingBox:
                Gizmos.DrawWireCube(transform.position, Vector3.one * size);
                break;
            case OverlapType.Sphere:
                Gizmos.DrawWireSphere(transform.position, size * 0.5f);
                break;
        }

        Gizmos.color = Color.red;
        if (colliders != null) {
            foreach (var collider in colliders) {
                Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
            }
        }
    }
}
