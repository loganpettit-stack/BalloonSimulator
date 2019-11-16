/* uiValuesUpdate.cs
 * 10.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Script obtains the scale value of the radius slider. The slider
 * value is converted from centimeters to radius in meters. The function called
 * will calculate volume and surface area. The radius, volume, and surface
 * area is used to update the databox UI.
 */

using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class gm_uiValuesUpdate : MonoBehaviour
{
    public Slider slider;
    public GameObject _balloon;
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
    public float mylar_mass;

    public void Start()
    {
        updateUI();
    }

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
        volume = 4.0f / 3.0f * pi * (innerRadius * innerRadius * innerRadius);
    }

    public void updateUI()
    {
        currentRadiusCM = slider.value;
        getRadius(currentRadiusCM);
        getSurfaceArea(currentRadiusM);
        getVolume(currentRadiusM);
        liftForce = balloon_properties.balloon_buoyancy(currentRadiusCM);
        mylar_mass = balloon_properties._Mylar_Mass(currentRadiusCM);
        //_balloon.GetComponent<Rigidbody2D>().mass = mylar_mass;
        //Debug.Log(" Radius: " + currentRadiusM + " SA: " + surfaceArea + " Volume: " + volume + "Lift Force: " + liftForce);
        dataBox.SetRadiusValue(currentRadiusM);
        dataBox.SetSurfaceAreaValue(surfaceArea);
        dataBox.SetVolumeValue(volume);
        dataBox.SetForceValue(liftForce);
    }
}
