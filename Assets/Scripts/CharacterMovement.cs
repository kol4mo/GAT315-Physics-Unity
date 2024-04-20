using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour {

    private CharacterController controller;
    private Vector3 velocity;
    private bool onGround;
    [SerializeField] Transform view;
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] float pushPower = 2.0f;
    [SerializeField] float rotationRate;
    [SerializeField] Animator ani;
    [SerializeField] Rig rig;

    private void Start() {
        controller = gameObject.GetComponent<CharacterController>();

        rig.weight = ani.GetBool("Equipped") ? 1 : 0;
    }

    void Update() {
        onGround = controller.isGrounded;
        ani.SetBool("OnGround", onGround);
        if (onGround && velocity.y < 0) {
            velocity.y = 0f;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1);
        move = Quaternion.Euler(0, view.rotation.eulerAngles.y, 0)  * move;
        controller.Move(move * Time.deltaTime * speed);
        ani.SetFloat("Speed", move.magnitude * speed);
        

        if (move != Vector3.zero) {
            //gameObject.transform.forward = move;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), rotationRate * Time.deltaTime);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && onGround) {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);//physics.gravity.y for unitys defined gravity
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            ani.SetBool("Equipped", !ani.GetBool("Equipped"));
            rig.weight = ani.GetBool("Equipped") ? 1 : 0;
        }



        velocity.y += gravityValue * Time.deltaTime;
        ani.SetFloat("VelocityY", velocity.y);
        controller.Move(velocity * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic) {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3) {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}
