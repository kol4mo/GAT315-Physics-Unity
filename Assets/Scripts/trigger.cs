using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField] GameObject ui;

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            ui.SetActive(true);   
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            ui.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
