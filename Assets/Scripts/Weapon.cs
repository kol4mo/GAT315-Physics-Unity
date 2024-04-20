using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform emmission;
    [SerializeField] AudioSource audioSource;
    [SerializeField] IntVariable ammoAmount;
    [SerializeField] BoolVariable finished;

    GameObject fired;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && fired == null && ammoAmount.value > 0) {
            audioSource.Play();
            fired = Instantiate(ammo,emmission.position, emmission.rotation);
            ammoAmount.value--;
        }

        if (fired == null && ammoAmount == 0) {
            finished.value = true;
        }
    }
}