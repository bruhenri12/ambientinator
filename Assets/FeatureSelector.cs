using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Features
{
    decorate,
    paint,
    iluminate
}

public class FeatureSelector : MonoBehaviour
{
    public static FeatureSelector Instance {  get; private set; }

    public Features ActiveFeature { get; private set; }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeFeature(string feature)
    {
        ActiveFeature = Enum.Parse<Features>(feature);
        print("ActiveFeature is now " + ActiveFeature.ToString());
    }

}
