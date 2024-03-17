using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using System.Drawing;
using Meta.WitAi;
using Unity.Burst.CompilerServices;
using System.Linq;
using Color = UnityEngine.Color;
using JetBrains.Annotations;

public class WallDetector : MonoBehaviour
{
    [SerializeField] SceneDebugger debugger;
    [SerializeField] Material[] colorsMaterials; 

    UnityEngine.Color newWallColor;
    GameObject debugCube;
    List<GameObject> debugCubes = new List<GameObject>();

    int currentColorIndex = 0;
    Material CurrentColorMaterial { get { return colorsMaterials[currentColorIndex]; } }

    private void Start()
    {
    
    }

    private void Update()
    {
        Vector3 rayOrigin = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        Vector3 rayDirection = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward;
        Ray ray = new Ray(rayOrigin, rayDirection);
        RaycastHit hit = new RaycastHit();
        MRUKAnchor anchorHit = null;
        MRUK.Instance?.GetCurrentRoom()?.Raycast(ray, Mathf.Infinity, out hit, out anchorHit);

        if (anchorHit != null)
        {
            debugger.ShowDebugAnchorsDebugger(isWall(anchorHit));

            if ((Input.GetMouseButtonDown(0) || OVRInput.GetDown(OVRInput.RawButton.A)) && isWall(anchorHit))
            {
                paintWall(anchorHit);
            }

            if ((Input.GetMouseButtonDown(1) || OVRInput.GetDown(OVRInput.RawButton.B)))
            {
                currentColorIndex = (currentColorIndex + 1) % colorsMaterials.Length;
            }
        }
    }

    bool isWall(MRUKAnchor anchor)
    {
        for (int i = 0; i < anchor.AnchorLabels.Count; i++)
        {
            if (anchor.AnchorLabels[i] == "WALL_FACE")
            {
                return true;
            }
        }
        return false;
    }

    void paintWall(MRUKAnchor anchor)
    {
        Debug.Log("aa");

        newWallColor = new UnityEngine.Color(1, 1, 1);
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        CreateDebugPrimitives(newCube);
        debugCubes.Add(newCube);

        GameObject currCube = debugCubes.Last();
        currCube.transform.localScale = new Vector3(anchor.GetAnchorSize().x, anchor.GetAnchorSize().y, 0.01f);
        currCube.transform.localPosition = anchor.transform.position - new Vector3(0.1f,0,0.1f);
        currCube.transform.localRotation = anchor.transform.rotation;
        currCube.GetComponent<MeshRenderer>().material = CurrentColorMaterial;
        currCube.AddComponent<BoxCollider>();
        currCube.tag = "WallPaint";
        currCube.SetActive(true);
    }


    void CreateDebugPrimitives(GameObject debugCube)
    {
        // debugCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        debugCube.GetComponent<Renderer>().material.color = UnityEngine.Color.green;
        debugCube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        debugCube.GetComponent<Collider>().enabled = false;
        debugCube.SetActive(false);
    }

}
