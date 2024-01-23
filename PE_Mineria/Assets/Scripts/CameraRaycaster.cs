using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                print(hit.collider);
            }
        }
    }
}
