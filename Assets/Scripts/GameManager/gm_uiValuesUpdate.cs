/* uiValuesUpdate.cs
 * 10.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Script obtains the scale value of the radius slider. The slider
 * value is converted from centimeters to radius in meters. The function called
 * will calculate volume and surface area. The radius, volume, and surface
 * area is used to update the databox UI.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class gm_uiValuesUpdate : MonoBehaviour
{
    public Slider slider;
    public gm_updatedatbbox dataBox;
    public balloon_properties balloon_properties;
    public float currentRadiusCM;
    public float currentRadiusM;
    public float surfaceArea;
    public float volume;
    public float pi = 3.1415926535f;
    public float mylar = 0.000016f;
    public float innerRadius;
    public float liftForce;
    
    // radius conversion from centimeters to meters
    public void getRadius(float radius)
    {
        currentRadiusM = radius / 100;
    }
    // surface area formula
    public void getSurfaceArea(float radius)
    {
        surfaceArea = 4 * pi * (radius * radius);
    }
    // volume formula using inner radius of balloon excluding mylar width
    public void getVolume(float radius)
    {
        innerRadius = radius - mylar;
        volume = 4 / 3 * pi * (innerRadius * innerRadius * innerRadius);
    }

    public void updateUI()
    {
        currentRadiusCM = slider.value;
        getRadius(currentRadiusCM);
        getSurfaceArea(currentRadiusM);
        getVolume(currentRadiusM);
        liftForce = balloon_properties.balloon_buoyancy(currentRadiusCM);
        //Debug.Log(" Radius: " + currentRadiusM + " SA: " + surfaceArea + " Volume: " + volume + "Lift Force: " + liftForce);
        dataBox.SetRadiusValue(currentRadiusM);
        dataBox.SetSurfaceAreaValue(surfaceArea);
        dataBox.SetVolumeValue(volume);
        dataBox.SetForceValue(liftForce);
    }
}
