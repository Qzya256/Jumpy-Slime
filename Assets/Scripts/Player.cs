using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    private Animator slimeAnimator;
    private Rigidbody2D playerRigidbody;
    private bool getReadyToJumpBoolean;
    private bool leftMooveBoolean;
    private bool righMooveBoolean;
    public bool IsGrounded;
    [Header("Motion settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float mooveSpeed;
    [SerializeField] private float directionJumpForce;
    [SerializeField] private float maxJumpForce;
    [SerializeField] private float acelerationJumpForce;
    [Header("Required components")]
    [SerializeField] private Collider2D colliderIsGrounded;
    [SerializeField] private AudioSource sfxAudioSourse;
    [SerializeField] private AudioClip jumpClip;


    private void Start()
    {
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
        slimeAnimator = transform.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        slimeAnimator.SetBool("ReadyToJump", getReadyToJumpBoolean);
        slimeAnimator.SetBool("IsGrounded", IsGrounded);
        //we determine whether the player is on the ground, if on the ground, then we allow him to prepare for the jump
        if (!IsGrounded)
        {
            if (playerRigidbody.velocity.y < 0)
            {
                slimeAnimator.SetBool("ReadyToJump", false);
                slimeAnimator.SetBool("Falling", true);
            }
        }
        else
        {
            slimeAnimator.SetBool("Falling", false);
        }
        //we move the player in the direction, checking before that whether he is on the ground and whether he is going to jump
        if (leftMooveBoolean)
        {
            if (IsGrounded && !getReadyToJumpBoolean)
            {
                slimeAnimator.SetBool("Move", true);
                transform.Translate(Vector3.left * mooveSpeed);
            }
        }

        if (righMooveBoolean)
        {
            if (IsGrounded && !getReadyToJumpBoolean)
            {
                slimeAnimator.SetBool("Move", true);
                transform.Translate(Vector3.right * mooveSpeed);
            }
        }
        //synchronizing the player's landing with the animation
        if (getReadyToJumpBoolean && jumpForce < maxJumpForce && IsGrounded && slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName("SlimeJump1"))
        {
            jumpForce = jumpForce + acelerationJumpForce;
        }
    }

    #region UI-related control methods
    public void LeftMove()
    {
        if (!righMooveBoolean)
        {
            leftMooveBoolean = true;
        }
    }

    public void RightMove()
    {
        if (!leftMooveBoolean)
        {
            righMooveBoolean = true;
        }
    }
    public void StopLeftMove()
    {
        slimeAnimator.SetBool("Move", false);
        leftMooveBoolean = false;
    }

    public void StopRightMove()
    {
        slimeAnimator.SetBool("Move", false);
        righMooveBoolean = false;
    }

    public void GetReadyToJump()
    {
        slimeAnimator.SetBool("ReadyToJump", true);
        getReadyToJumpBoolean = true;
    }

    public void Jump()
    {
        slimeAnimator.SetBool("ReadyToJump", false);
        playerRigidbody.AddForce(Vector2.up * jumpForce);
        if (jumpForce > (maxJumpForce/3f))
        {
            sfxAudioSourse.PlayOneShot(jumpClip);
        }
        if (leftMooveBoolean)
        {
            playerRigidbody.AddForce(Vector2.left/directionJumpForce * jumpForce);
        }
        else if (righMooveBoolean)
        {
            playerRigidbody.AddForce(Vector2.right/directionJumpForce * jumpForce);
        }
        jumpForce = 0;
        getReadyToJumpBoolean = false;
    }
    #endregion
}
