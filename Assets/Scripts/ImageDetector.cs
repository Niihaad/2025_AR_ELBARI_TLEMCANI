using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageDetector : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;
    public ARPlaneManager planeManager;

    public GameObject gameContent;     
    public GameObject spawnScript;
    public GameObject arePlan;

    private bool cakePlaced = false;

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    void Start()
    {
        gameContent.SetActive(false);
        arePlan.SetActive(false);
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage img in args.added)
        {
            if (img.referenceImage.name == "TarteImage")
            {
                PlaceCakeOnPlane();
            }
        }
    }

    void PlaceCakeOnPlane()
    {
        if (cakePlaced) return;
        foreach (UnityEngine.XR.ARFoundation.ARPlane plane in planeManager.trackables)
        {
            if (plane.alignment == PlaneAlignment.HorizontalUp)
            {
                Vector3 position = plane.center;
                gameContent.transform.position = position;
                gameContent.SetActive(true);

                spawnScript.GetComponent<spawnScript>().StartSpawning();
                cakePlaced = true;
                break;
            }
        }
    }
}
