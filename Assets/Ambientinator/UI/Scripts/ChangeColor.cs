using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Light lightingObj;
    public void changeColor(GameObject gameObject){
        if (lightingObj)
        {
            lightingObj.color = gameObject.GetComponent<Image>().color;
        }
    }
}
