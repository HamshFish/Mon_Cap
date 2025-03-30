using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player_Move : MonoBehaviour
{

    public Camera cam;
    Rigidbody rb;

    Vector2 input;
    bool isGrounded = false;

    float jumpSpeed = 300;
    float moveSpeed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (cam == null) { cam = Camera.main; }
        if (cam == null) { cam = FindFirstObjectByType<Camera>(); }
    }

    void OnJump()
    {
        if (!isGrounded) return;
        rb.AddForce(Vector3.up * jumpSpeed);
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        if (input.magnitude > 1)
        {
            input.Normalize();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement3D = new Vector3(input.x, 0f, input.y);
        movement3D = cam.transform.TransformDirection(movement3D);
        movement3D.y = 0f;
        movement3D = movement3D.normalized * movement3D.magnitude;

        rb.AddForce(movement3D * moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 floorNormal = collision.contacts[0].normal.normalized;
        if (Vector3.Dot(floorNormal, Vector3.up) > 0.5)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
