using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjLighting : MonoBehaviour
{
    public GameObject lightingObjPrefab;
    public GameObject test;
    // Start is called before the first frame update
    public void assignObject(GameObject obj){
        lightingObjPrefab = obj;
        spawnPrefab(obj);
    }
    public void spawnPrefab(GameObject prefabToInstantiate){
        // Check if the prefab is assigned
        if (prefabToInstantiate != null)
        {
            // Instantiate the prefab at its default position and rotation
            GameObject instantiatedObject = Instantiate(prefabToInstantiate);

            // You can now manipulate or access the instantiatedObject as needed
        }
        else
        {
            Debug.LogError("Prefab not assigned in the inspector!");
        }
    }
}
