using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Rigidbody rigidbody;

    private float distToGround;
    private float timeSinceJump = 0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            animator.SetTrigger("jump");
            timeSinceJump = 3.5f;
            rigidbody.AddForce(Vector3.up * 16f, ForceMode.Impulse);
        }
        timeSinceJump -= Time.deltaTime;
    }

    bool CanJump()
    {
        return (timeSinceJump < 0f);
        //return Physics.Raycast(transform.position, -Vector3.up, distToGround + 10.5f);
    }
}
