using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunBaby : MonoBehaviour
{
    public GameObject leftThruster;
    public GameObject rightThruster;
    public GameObject bottomThruster;

    public Animator leftAnimator;
    public Animator rightAnimator;
    public Animator bottomAnimator;

    private float thrusterForce = 15f;

    public Rigidbody2D torso;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) && CanControl())
        {
            Vector3 force = CalculateForce(bottomThruster.transform.position);
            torso.AddForceAtPosition(force, bottomThruster.transform.position);

            bottomAnimator.SetBool("isFiring", true);
        } else {
            bottomAnimator.SetBool("isFiring", false);
        }

        if (Input.GetKey(KeyCode.A) && CanControl())
        {
            Vector3 force = CalculateForce(leftThruster.transform.position);
            torso.AddForceAtPosition(force, leftThruster.transform.position);

            leftAnimator.SetBool("isFiring", true);
        } else {
            leftAnimator.SetBool("isFiring", false);
        }
        if (Input.GetKey(KeyCode.D) && CanControl())
        {
            Vector3 force = CalculateForce(rightThruster.transform.position);
            torso.AddForceAtPosition(force, rightThruster.transform.position);

            rightAnimator.SetBool("isFiring", true);
        } else {
            rightAnimator.SetBool("isFiring", false);
        }

        if (Input.GetKey(KeyCode.Space) && CanControl())
        {
            float torque = -(torso.rotation - 90f) * 10f;
            torso.AddTorque(torque);
        }

        if (Input.GetKey(KeyCode.R) && CanControl())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public bool CanControl()
    {
        return !torso.gameObject.GetComponent<GunBabyWinTriggerController>().isWon;
    }

    Vector3 CalculateForce(Vector3 position)
    {
        Vector3 torsoPosition = torso.transform.position;
        Vector3 force = (torsoPosition - position).normalized * thrusterForce;
        return force;
    }

}
