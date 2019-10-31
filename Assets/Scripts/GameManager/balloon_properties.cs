using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloon_properties : MonoBehaviour
{
    public Slider slider;
    public float gravity = 9.81f;
    public float helium_density = 0.179f;
    public float air_density = 1.29f;
    public float mylar_density = 0.00139f;
    public float mylar_thickness = 0.000016f;
    public float Fb;
    public float lift_force;
    public float Bvolume;
    public float Hvolume;
    public float Whe;
    public float Wbm;
    public float cmToMeters;
    public float value;

    public void Start()
    {
        /* get slider value */
        slider = gm_slidebarhandler.FindObjectOfType<Slider>();
    }

    void Update()
    {
       
        //Debug.Log(balloon_buoyancy(slider.value));
    }

    public float balloon_buoyancy(float radius)
    {
        /* Inner and outter volume of balloon */
        Bvolume = Volume(radius);
        Hvolume = Volume(radius - mylar_thickness);
        /* weight of mylar and helium */
        Wbm = mylar_density * (Bvolume - Hvolume);
        Whe = helium_density * Hvolume;
        /* buoyant force of balloon */
        Fb = air_density * Bvolume;
        /* subtract wieghts of mylar and helium from buoyant force to get actual lift force */
        lift_force = (Fb - (Whe + Wbm)) * gravity;

        return lift_force;
    }

    public float Volume(float radius)
    {
        /* convert cm slider value to meters */
        cmToMeters = radius / 100;
        value = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(cmToMeters, 3);
        return value;
    }
    
}
