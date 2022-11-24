using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    [SerializeField] private float windForce;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && !other.GetComponent<Player>().IsGrounded)
        {
            other.GetComponent<Rigidbody2D>().AddForce(Vector3.right * windForce);
        }
    }
}
