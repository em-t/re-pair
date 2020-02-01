using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpForce;

    private Vector3 point;

    public LayerMask jumpables;

    private Rigidbody rig;
    private CapsuleCollider collider;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        Debug.Log("Game object: " + gameObject);
    }

    void FixedUpdate()
    {
        PlayerMovement();
        point = rig.position;
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(hor, 0f, ver);

        //gameObject.transform.Translate(direction.normalized * speed * Time.deltaTime);
        //float angle = Vector3.Angle(gameObject.transform.forward, direction);
        //gameObject.transform.Rotate(0f, angle, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(point, -Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(point, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z),
            collider.radius * .9f, jumpables);
    }
}

