using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PropertiesOfObj : MonoBehaviour
{
    [System.NonSerialized]
    public Light lightingObj;
    public Slider sliderIntensity;

    public TextMeshProUGUI nameObj;
    public void changeColor(GameObject gameObject){
        if(gameObject.GetComponent<Image>() && lightingObj)
        {
            lightingObj.color = gameObject.GetComponent<Image>().sprite.texture.GetPixel(1,1);
        }
    }

    public void changeIntensity(Slider slider){
        lightingObj.intensity = slider.value;
    }

    public void DestroyThis(){
        Destroy(gameObject);
    }
}
