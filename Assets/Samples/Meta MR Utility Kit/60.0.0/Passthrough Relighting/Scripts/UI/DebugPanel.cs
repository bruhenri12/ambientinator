/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Meta.XR.MRUtilityKit;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    [SerializeField] private Slider intensitySlider;
    [SerializeField] private  Light pointLight;
    [SerializeField] private Slider areaSlider;
    [SerializeField] private Slider colorSlider;

    [SerializeField] private Material sceneMaterial;
    private bool pressed;

    private EffectMesh[] effectMeshes;
    private const string HighLightAttenuationShaderPropertyName = "_HighLightAttenuation";

    private void Awake()
    {
        pressed = false;
        effectMeshes = FindObjectsOfType<EffectMesh>();
    }
    
    private void Update(){
        if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x == 0f && OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y == 0f){
            pressed = false;
        }
        // returns true if the primary button (typically “A”) is currently pressed.
        if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x == 1.0f && !pressed){
            Debug.Log("aumentou intensidade em 1");
            if(pointLight.intensity < 5){
                pointLight.intensity += 1;
                intensitySlider.value += 1;
            }
            pressed = true;
        }
        if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x == -1.0f && !pressed){
            Debug.Log("diminuiu intensidade em 1");
            if(pointLight.intensity > 0){
                pointLight.intensity -= 1;
                intensitySlider.value -= 1;
            }
            pressed = true;
        }
        if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y == 1.0f && !pressed){
            Debug.Log("aumentou area em 1");
            if(pointLight.range < 5){
                pointLight.range += 1;
                areaSlider.value += 1;
            }
            pressed = true;
        }
        if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y == -1.0f && !pressed){
            Debug.Log("diminuiu area em 1");
            if(pointLight.range > 0){
                pointLight.range -= 1;
                areaSlider.value -= 1;
            }
            pressed = true;
        }

        if(OVRInput.GetDown(OVRInput.Button.One)){
            Debug.Log("mudou cor");
            if(colorSlider.value > 0){
                colorSlider.value -= 0.5f;
                pointLight.color = Color.Lerp(Color.red, Color.green, colorSlider.value / 5);
            }

        }

        if(OVRInput.GetDown(OVRInput.Button.Two)){
            Debug.Log("mudou cor");
            if(colorSlider.value < 5){
                colorSlider.value += 0.5f;
                pointLight.color = Color.Lerp(Color.red, Color.green, colorSlider.value / 5);
            }

        }

    }
}
