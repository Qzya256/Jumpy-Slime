using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravityTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            playerRigidbody.gravityScale = 2f;
            Time.timeScale = 0.7f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            playerRigidbody.gravityScale = 3f;
            Time.timeScale = 1f;
        }
    }

}
