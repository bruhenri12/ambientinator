using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintUI : MonoBehaviour
{
    private void Start()
    {
        Toggle toogles = GetComponentInChildren<Toggle>();
        toogles.onValueChanged.AddListener(delegate { ChangeActiveColor(); });
    }

    public void ChangeActiveColor()
    {

        print(gameObject.name);
    }
}
