using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float initialOrotgraphicSize;
    private Camera cam;
    private void Awake()
    {
        cam = GetComponent<Camera>();
        initialOrotgraphicSize = cam.orthographicSize;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }
    public void SetCameraPosition(Transform trans, float ortographicSize)
    {
        cam.orthographicSize = ortographicSize;
        this.transform.position = trans.position;
        this.transform.rotation = trans.rotation;
        
    }
    public void SetCameraToOrigin()
    {
        cam.orthographicSize = initialOrotgraphicSize;
        this.transform.position = initialPosition;
        this.transform.rotation = initialRotation;
    }
}
