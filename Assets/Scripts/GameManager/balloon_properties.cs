/*balloon_properties.cs
 * 11.18.2019
 * Balloon Physics simulator
 * Author: Team NoName
 * Description: Calculate lift force, volume, and mylar mass to be used by other scripts
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloon_properties : MonoBehaviour
{
    public Slider slider;
    float gravity = 9.81f;
    float helium_density = 0.179f;
    float air_density = 1.29f;
    float mylar_density = 0.00139f;
    float mylar_thickness = 0.000016f;
    float Fb;
    float lift_force;
    float Bvolume;
    float Hvolume;
    float Whe;
    float Wbm;
    float cmToMeters;
    float value;

    /*Calculating lift force of balloon*/
    public float balloon_buoyancy(float radius)
    {
        Bvolume = Volume(radius);
        Hvolume = Volume(radius - mylar_thickness);
        Wbm = mylar_density * (Bvolume - Hvolume);
        Whe = helium_density * Hvolume;
        Fb = air_density * Bvolume;
        lift_force = (Fb - (Whe + Wbm)) * gravity;

        return lift_force;
    }

    /*Seperate Volume function for easy use in other scripts*/
    public float Volume(float radius)
    {
        cmToMeters = radius / 100;
        value = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(cmToMeters, 3);
        return value;
    }

    /* Mylar Mass calculated seperately to apply on balloon Rigidbody 2D
     * for realistic physics simulation*/
    public float _Mylar_Mass(float radius)
    {
        float Surface_Area;
        float Mylar_Mass;

        Surface_Area = 4.0f * Mathf.PI * Mathf.Pow(radius, 2);
        Mylar_Mass = Surface_Area * mylar_thickness * mylar_density * 50;
        return Mylar_Mass;
    }
    
}
