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
    public Slider _slider; //Slider reference
    public gm_updatedatbbox _dataBox; //script reference 
    public balloon_properties _balloonProperties; //script reference 
    public float _currentRadiusCM; 
    public float _currentRadiusM;
    public float _surfaceArea;
    public float _volume;
    public float _pi = 3.1415926535f;
    public float _mylar = 0.000016f;
    public float _innerRadius;
    public float _liftForce;

    public void Start()
    {
        updateUI();
    }

    // radius conversion from centimeters to meters
    public void getRadius(float radius)
    {
        _currentRadiusM = radius / 100;
    }
    // surface area formula
    public void getSurfaceArea(float radius)
    {
        _surfaceArea = 4 * _pi * (radius * radius);
    }
    // volume formula using inner radius of balloon excluding mylar width
    public void getVolume(float radius)
    {
        _innerRadius = radius - _mylar;
        _volume = 4.0f / 3.0f * _pi * (_innerRadius * _innerRadius * _innerRadius);
    }

    public void updateUI()
    {
        _currentRadiusCM = _slider.value;
        getRadius(_currentRadiusCM);
        getSurfaceArea(_currentRadiusM);
        getVolume(_currentRadiusM);
        _liftForce = _balloonProperties.BalloonBuoyancy(_currentRadiusCM);
        //Debug.Log(" Radius: " + currentRadiusM + " SA: " + surfaceArea + " Volume: " + volume + "Lift Force: " + liftForce);
        _dataBox.SetRadiusValue(_currentRadiusM);
        _dataBox.SetSurfaceAreaValue(_surfaceArea);
        _dataBox.SetVolumeValue(_volume);
        _dataBox.SetForceValue(_liftForce);
    }
}
