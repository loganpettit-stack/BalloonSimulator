/* dataCollect.cs
 * 11.13.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Script contains a class for balloon data. It also creates a
 * balloon object that is updated using other functions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataCollect : MonoBehaviour
{
    public gm_uiValuesUpdate uiValues;
    // balloon object
    public BalloonData balloonData = new BalloonData();

    // Update is called once per frame
    void Update()
    {
        // updates balloon object's values
        balloonData.currentRadiusM = uiValues.currentRadiusM;
        balloonData.surfaceArea = uiValues.surfaceArea;
        balloonData.volume = uiValues.volume;
        balloonData.liftForce = uiValues.liftForce;
        //Debug.Log(" Radius: " + data.currentRadiusM + " SA: " + data.surfaceArea + " Volume: " + data.volume + " Lift Force: " + data.liftForce);
    }
}

// class of balloon properties
public class BalloonData {
    public float currentRadiusM;
    public float surfaceArea;
    public float volume;
    public float liftForce;
    public float mass;
}


