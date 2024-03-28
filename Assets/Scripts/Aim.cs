using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] float speed = 3;

    Vector3 rotation = Vector3.zero;
    Vector2 prevAxis = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        prevAxis.x = -Input.GetAxis("Mouse Y");
        prevAxis.y = Input.GetAxis("Mouse X");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.x = -Input.GetAxis("Mouse Y") - prevAxis.x;
        axis.y = Input.GetAxis("Mouse X") - prevAxis.y;

        rotation.x += axis.x * speed;
        rotation.y += axis.y * speed;

        rotation.x = Mathf.Clamp(rotation.x, -40, 40);
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);

        Quaternion qyaw = Quaternion.AngleAxis(rotation.y, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(rotation.x, Vector3.right);

        transform.localRotation = (qpitch * qyaw);
    }
}
