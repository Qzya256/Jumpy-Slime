using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoover : MonoBehaviour
{
    [SerializeField] private Transform poinToTranslateCam;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, poinToTranslateCam.position.y, cameraTransform.position.z);
        }
    }
}
