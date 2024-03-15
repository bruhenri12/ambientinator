using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public Furniture[] furnitures;
    GameObject prefab;
    GameObject currentPreview;

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.One)) {
            RemovePrefab();
        }
        if (!prefab && !currentPreview) return;

        Ray ray = new Ray(
            OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),
            OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            currentPreview.transform.position = hit.point;
            currentPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                Instantiate(prefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
    }

    public void ChangePrefab(int index)
    {
        if (prefab && currentPreview) RemovePrefab();
        prefab = furnitures[index].prefab;
        Destroy(currentPreview);
        currentPreview = furnitures[index].preview;
    }

    void RemovePrefab()
    {
        if (!prefab && !currentPreview) return;
        prefab = null;
        Destroy(currentPreview);
        currentPreview = null;
    }
}
