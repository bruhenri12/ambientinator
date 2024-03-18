using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Furniture
{
    public GameObject prefab;
    public GameObject preview;
}

public enum InteractionType
{
    None, Spawn, Move
}

public class FurnitureManager : MonoBehaviour
{
    public Furniture[] furnitures;

    GameObject prefab;
    GameObject currentPreview;

    InteractionType interaction = InteractionType.None;

    void Update()
    {
        Debug.Log(interaction);
        Ray ray = new Ray(
            OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch),
            OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (interaction == InteractionType.Spawn) {
                currentPreview.transform.position = hit.point;
                currentPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    Instantiate(prefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    RemovePrefab();
                    interaction = InteractionType.None;
                }
            }

            if (interaction == InteractionType.Move) {
                prefab.transform.position = hit.point;
                prefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    prefab.GetComponent<Collider>().enabled = true;
                    interaction = InteractionType.None;
                }
            }

            if (interaction == InteractionType.None) {
                Debug.Log(hit.transform.tag);
                if (OVRInput.GetDown(OVRInput.RawButton.A) && hit.transform.tag == "Furniture")
                {
                    prefab = hit.transform.gameObject;
                    prefab.GetComponent<Collider>().enabled = false;
                    interaction = InteractionType.Move;
                }
                if (OVRInput.GetDown(OVRInput.RawButton.B) && hit.transform.tag == "Furniture")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }

    }

    public void ChangePrefab(int index)
    {
        if (furnitures.Length <= index) return;
        if (prefab && currentPreview) RemovePrefab();
        prefab = furnitures[index].prefab;
        currentPreview = Instantiate(furnitures[index].preview);
        currentPreview.GetComponent<Collider>().enabled = false;
        interaction = InteractionType.Spawn;
    }

    public void MovePrefab(GameObject selectedPrefab)
    {
        prefab = selectedPrefab;
        interaction = InteractionType.Move;
    }

    void RemovePrefab()
    {
        if (!prefab && !currentPreview) return;
        prefab = null;
        Destroy(currentPreview);
        currentPreview = null;
    }
}
