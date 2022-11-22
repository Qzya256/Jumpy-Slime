using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSwitch : MonoBehaviour
{
    [SerializeField] private GameObject houseLightOn;
    [SerializeField] private GameObject houseLightOff;
    [SerializeField] private ParticleSystem houseSmoke;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            houseLightOn.SetActive(false);
            houseLightOff.SetActive(true);
            houseSmoke.enableEmission = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            houseLightOn.SetActive(true);
            houseLightOff.SetActive(false);
            houseSmoke.enableEmission = true;
        }
    }
}
