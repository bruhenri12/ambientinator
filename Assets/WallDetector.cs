using Meta.XR.MRUtilityKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;

public class WallDetector : MonoBehaviour
{
    [SerializeField] SceneDebugger debugger;

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
}
