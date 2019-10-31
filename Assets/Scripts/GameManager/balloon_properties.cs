using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloon_properties : MonoBehaviour
{
    public Slider slider;
    public float radius;

    void Update()
    {
        radius = slider.value;
        Debug.Log(balloon_buoyancy(radius));
    }

    public float balloon_buoyancy(float radius)
    {
        // m/s^2
        float gravity = 9.8f;

        // currently in kg/m^3
        float helium_density = 0.179f;
        float air_density = 1.29f;
        float mylar_density = 0.00139f;

        // Newton Meters
        float Fb;
        float lift;

        float volume;

        // Weight of helium in balloon
        float Whe;

        // Weight of balloon material
        float Wbm;

        volume = (4.0f / 3.0f) * Mathf.PI * Mathf.Pow(radius, 3);
        Whe = helium_density * volume * gravity;
        Wbm = mylar_density * volume * gravity;
        Fb = air_density * volume * gravity;
        lift = Fb - (Whe + Wbm);

        return lift;
    }
    
}
