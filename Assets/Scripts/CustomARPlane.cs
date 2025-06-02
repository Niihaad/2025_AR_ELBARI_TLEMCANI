using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ARPlane))]
public class CustomARPlane : MonoBehaviour
{
    private UnityEngine.XR.ARFoundation.ARPlane  plane;
    private NativeArray<Vector2> previousBoundary;

    void Awake()
    {
        plane = GetComponent<ARPlane>();
    }

    void Update()
    {
        var currentBoundary = plane.boundary;


        if (!previousBoundary.IsCreated || HasBoundaryChanged(currentBoundary))
        {
            Debug.Log("Plan détecté ou mis à jour.");
            if (previousBoundary.IsCreated)
                previousBoundary.Dispose();

            previousBoundary = new NativeArray<Vector2>(currentBoundary, Allocator.Persistent);
        }
    }

    bool HasBoundaryChanged(NativeArray<Vector2> current)
    {
        if (!previousBoundary.IsCreated || previousBoundary.Length != current.Length)
            return true;

        for (int i = 0; i < current.Length; i++)
        {
            if (Vector2.Distance(previousBoundary[i], current[i]) > 0.01f)
                return true;
        }

        return false;
    }

    private void OnDestroy()
    {
        if (previousBoundary.IsCreated)
            previousBoundary.Dispose();
    }
}
