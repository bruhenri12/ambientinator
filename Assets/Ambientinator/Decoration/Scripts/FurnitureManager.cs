using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Furniture
{
    public GameObject prefab;
    public GameObject preview;
}

public class FurnitureManager : MonoBehaviour
{
    public Furniture[] furnitures;

    GameObject prefab;
    GameObject currentPreview;

    void Update()
    {
        if (prefab && currentPreview) {
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
                    RemovePrefab();
                }
            }
        }
    }

    public void ChangePrefab(int index)
    {
        if (furnitures.Length <= index) return;
        if (prefab && currentPreview) RemovePrefab();
        prefab = furnitures[index].prefab;
        prefab.tag = "Furniture";
        Destroy(currentPreview);
        currentPreview = Instantiate(furnitures[index].preview);
    }

    void RemovePrefab()
    {
        if (!prefab && !currentPreview) return;
        prefab = null;
        Destroy(currentPreview);
        currentPreview = null;
    }
}
