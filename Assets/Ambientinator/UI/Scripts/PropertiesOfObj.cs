using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class PropertiesOfObj : MonoBehaviour
{
    [System.NonSerialized]
    public Light lightingObj;
    public void changeColor(GameObject gameObject){
        lightingObj.color = gameObject.GetComponent<Image>().sprite.texture.GetPixel(1,1);
    }

    public void changeIntensity(Slider slider){
        lightingObj.intensity = slider.value;
    }
}
