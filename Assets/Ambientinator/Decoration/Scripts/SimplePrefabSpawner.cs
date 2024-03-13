using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePrefabSpawner : MonoBehaviour
{
    GameObject prefab;
    GameObject currentPreview;

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.One)) {
            prefab = null;
            Destroy(currentPreview);
            currentPreview = null;
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

    public void ChangePrefab(GameObject newPrefab) {
        if (!newPrefab) return;
        this.prefab = newPrefab;
    }
    public void ChangePreviewPrefab(GameObject newPreviewPrefab) {
        if (!newPreviewPrefab) return;
        Destroy(this.currentPreview);
        this.currentPreview = Instantiate(newPreviewPrefab);
    }
}
