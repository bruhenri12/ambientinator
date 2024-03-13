using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePropertiesMenu : MonoBehaviour
{
    public GameObject menuPrefab;

    public void assignObject(GameObject obj){
        if(obj != menuPrefab){
            menuPrefab = obj;
            spawnPrefab(obj);
        }
    }
    public void spawnPrefab(GameObject prefabToInstantiate){
        // Check if the prefab is assigned
        if (prefabToInstantiate != null)
        {
            // Instantiate the prefab at its default position and rotation
            GameObject instantiatedObject = Instantiate(prefabToInstantiate);
            print(this.gameObject.GetComponent<Light>());
            Light lightSrc = this.gameObject.GetComponent<Light>();
            instantiatedObject.GetComponent<PropertiesOfObj>().lightingObj = lightSrc;

            // You can now manipulate or access the instantiatedObject as needed
        }
        else
        {
            Debug.LogError("Prefab not assigned in the inspector!");
        }
    }
}
