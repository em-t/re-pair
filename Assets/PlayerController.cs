using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Vector3 point;

    public LayerMask jumpables;

    private Rigidbody rig;
    private CapsuleCollider collider;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
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

        //if (direction != Vector3.zero)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        //    transform.rotation = rotation;
        //}

        rig.velocity = new Vector3(hor * speed, rig.velocity.y, ver * speed);

        rig.freezeRotation = true;

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

