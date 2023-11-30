using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    //float idleTime = 0.4f;
    //float timer = 0.0f;
    Animator m_Animator;
    Rigidbody m_Rigidbody; // will be used to apply mvmt and rotation to character since the character needs to be part of the physics system
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    //Quaternions are a way of storing rotations
    Quaternion m_Rotation = Quaternion.identity;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Use FixedUpdate for physics and Update for rendering
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        //returns false if the horizontal input is not entered and true otherwise
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);



        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }


        // transform towards the movement variable changing by angle turnspeed ... with magnitude of 0
        // Time.delta_time is the time since the previous frame: time between frames
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    /// <summary>
    /// Allows you to apply movement and rotation separately
    /// </summary>
    void OnAnimatorMove()
    {
        // to current position add direction * length: movement
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);

    }
}
