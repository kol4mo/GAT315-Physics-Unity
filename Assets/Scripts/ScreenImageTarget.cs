using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImageTarget : MonoBehaviour {
    [SerializeField] Image img;
    [SerializeField] Camera view;
    [SerializeField] float distance;

    private void LateUpdate() {
        Vector3 screen = img.transform.position;
        screen.z = distance;
        Vector3 world = view.ScreenToWorldPoint(screen);
        transform.position = world;
    }
}
