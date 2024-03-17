using System;
using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratePropertiesMenu : MonoBehaviour
{
    public GameObject menuPrefab;
    public String nome;

    public void assignObject(GameObject obj){         
        spawnPrefab(obj);
    }
    public void spawnPrefab(GameObject prefabToInstantiate){
        // Check if the prefab is assigned
        if (prefabToInstantiate != null)
        {
            
            if(GameObject.FindGameObjectWithTag("PropertiesController").TryGetComponent<PropertiesMenuController>(out var propertiesController))
            {
                if(propertiesController.selectedObj != null && propertiesController.selectedObj != prefabToInstantiate){
                    if(propertiesController.selectedObj.TryGetComponent<PropertiesOfObj>(out var tempController)){
                        print("oi");
                        tempController.DestroyThis();
                        propertiesController.selectedObj = null;
                    }
                    
                }

                if(propertiesController.selectedObj == null){
                    // Instantiate the prefab at its default position and rotation
                    GameObject instantiatedObject = Instantiate(prefabToInstantiate);
                    print(this.gameObject.GetComponent<Light>());
                    Light lightSrc = this.gameObject.GetComponent<Light>();
                    PropertiesOfObj pObj = instantiatedObject.GetComponent<PropertiesOfObj>();
                    pObj.nameObj.text = "Properties of " + nome;
                    pObj.lightingObj = lightSrc;
                    pObj.sliderIntensity.value = lightSrc.intensity;
                    propertiesController.selectedObj = instantiatedObject;
                }
            } else {
                Debug.LogError("PropertiesMenuController not found.");
            }
        }
        else
        {
            Debug.LogError("Prefab not assigned in the inspector!");
        }
    }
}
