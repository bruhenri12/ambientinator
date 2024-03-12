using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PaintUINode : MonoBehaviour
{
    TMP_Text textUI;
    Color nodeColor;

    public Action<Color> onColorChanged;

    //private void Start()
    //{
    //    Toggle[] toggles = GetComponentsInChildren<Toggle>();

    //    for (int i = 0; i < toggles.Length; i++) {
    //        print(toggles + " " + i);
    //        toggles[i].onValueChanged.AddListener(ChangeActiveColor);
    //    }
    //}

    private void OnEnable()
    {
        textUI = GetComponentInChildren<TMP_Text>();
        nodeColor = GetComponent<Toggle>().colors.normalColor;
    }

    public void ChangeActiveColor(bool active)
    {
        if (active)
            onColorChanged?.Invoke(nodeColor);
    }
}
