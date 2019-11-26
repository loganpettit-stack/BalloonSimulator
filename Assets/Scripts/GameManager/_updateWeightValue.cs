/* _updateWeightValue.cs
 * 11.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Change the value of the weight based on 
 * balloon lift force plus wind.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _updateWeightValue : MonoBehaviour
{
    public Wind weight;
    public float force;
    public GameObject value;
    public float val;


    /*Grab TextMesh Pro object*/
    void Start()
    {
        value = GameObject.Find("ROOT/WEIGHT/Canvas/Text").gameObject;
        val = 1000;
    }
    /*Update force on weight*/
    void Update()
    {
        force = Wind.WeightForce();

        if(force > 0)
        {
            var test = val - (force/9.81f);
            value.GetComponent<TextMeshProUGUI>().text = test.ToString("F0") + "Kg";
        }
        

    }


}
