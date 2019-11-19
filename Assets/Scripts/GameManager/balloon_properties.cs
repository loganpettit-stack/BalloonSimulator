/* balloon_properties.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Defines properties of the balloon and contains some of the calculations needed for operations
 * 
 */

using UnityEngine;
using UnityEngine.UI;

public class balloon_properties : MonoBehaviour
{
    public Slider _slider;
    float _gravity = 9.81f;
    float _helium_density = 0.179f;
    float _air_density = 1.29f;
    float _mylar_density = 0.00139f;
    float _mylar_thickness = 0.000016f;
    float _Fb;
    float _lift_force;
    float _Bvolume;
    float _Hvolume;
    float _Whe;
    float _Wbm;
    float _cmToMeters;
    float _value;

    /*Calculate force of lift balloon has*/
    public float BalloonBuoyancy(float radius)
    {
        _Bvolume = Volume(radius);
        _Hvolume = Volume(radius - _mylar_thickness);
        _Wbm = _mylar_density * (_Bvolume - _Hvolume);
        _Whe = _helium_density * _Hvolume;
        _Fb = _air_density * _Bvolume;
        _lift_force = (_Fb - (_Whe + _Wbm)) * _gravity;

        return _lift_force;
    }
    /*Separated Volume so that other scripts can pull in calculation*/
    public float Volume(float radius)
    {
        _cmToMeters = radius / 100;
        _value = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(_cmToMeters, 3);
        return _value;
    }

    /*Function to calculate mass of mylar, weight multiplied by 50 
     * for realistic physics with Unity engine */
    public float _Mylar_Mass(float radius)
    {
        float Surface_Area;
        float Mylar_Mass;
        Surface_Area = 4.0f * Mathf.PI * Mathf.Pow(radius, 2);
        Mylar_Mass = Surface_Area * _mylar_thickness * _mylar_density * 50;
        return Mylar_Mass;
    }

}
