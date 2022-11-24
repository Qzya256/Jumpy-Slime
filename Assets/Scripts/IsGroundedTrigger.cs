using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedTrigger : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AudioSource sfxAudioSourse;
    [SerializeField] private AudioClip fallClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            sfxAudioSourse.PlayOneShot(fallClip);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            player.IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            player.IsGrounded = false;
        }
    }
}
