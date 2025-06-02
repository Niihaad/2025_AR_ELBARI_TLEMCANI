using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlane))]
[RequireComponent(typeof(LineRenderer))]
public class ARPlaneVisualizer : MonoBehaviour
{
    private UnityEngine.XR.ARFoundation.ARPlane arPlane;
    private LineRenderer lineRenderer;

    void Awake()
    {
        arPlane = GetComponent<ARPlane>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.loop = true;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.material.color = Color.red;
    }

    void Update()
    {
        var boundary = arPlane.boundary;

        lineRenderer.positionCount = boundary.Length;

        for (int i = 0; i < boundary.Length; i++)
        {

            Vector3 localPoint = new Vector3(boundary[i].x, 0, boundary[i].y);
            Vector3 worldPoint = arPlane.transform.TransformPoint(localPoint);
            lineRenderer.SetPosition(i, worldPoint);
        }
    }
}
