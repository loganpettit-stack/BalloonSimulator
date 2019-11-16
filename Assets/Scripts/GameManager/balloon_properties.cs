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

    public void Start()
    {
        /* get slider value */
        _slider = gm_slidebarhandler.FindObjectOfType<Slider>();
    }

    void Update()
    {

        //Debug.Log(balloon_buoyancy(slider.value));
    }

    public float BalloonBuoyancy(float radius)
    {
        /* Inner and outter volume of balloon */
        _Bvolume = Volume(radius);
        _Hvolume = Volume(radius - _mylar_thickness);
        /* weight of mylar and helium */
        _Wbm = _mylar_density * (_Bvolume - _Hvolume);
        _Whe = _helium_density * _Hvolume;
        /* buoyant force of balloon */
        _Fb = _air_density * _Bvolume;
        /* subtract wieghts of mylar and helium from buoyant force to get actual lift force */
        _lift_force = (_Fb - (_Whe + _Wbm)) * _gravity;

        return _lift_force;
    }

    public float Volume(float radius)
    {
        /* convert cm slider value to meters */
        _cmToMeters = radius / 100;
        _value = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(_cmToMeters, 3);
        return _value;
    }

}
