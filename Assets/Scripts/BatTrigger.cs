using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    [SerializeField] private Animator batAnimator;
    [SerializeField] private bool batTrigger; //I decided to use this script for other objects as well
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && batTrigger)
        {
            batAnimator.SetBool("Fly", true);
            Destroy(batAnimator.gameObject, 3f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null && !batTrigger)
        {
            batAnimator.enabled = true;
            Destroy(batAnimator.gameObject, 10f);
        }
    }
}
