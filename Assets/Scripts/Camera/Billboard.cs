using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        this.cam = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position - cam.transform.forward);
    }
}
