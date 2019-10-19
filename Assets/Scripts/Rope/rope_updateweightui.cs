using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rope_updateweightui : MonoBehaviour
{
    Text _ropeText;
    ConfigurableJoint _weightJoint;

    // Start is called before the first frame update
    void Start()
    {
        _weightJoint = gameObject.GetComponent<ConfigurableJoint>();
        _ropeText = GameObject.Find("RopeMag").GetComponent<Text>();
    }

    private void OnGUI()
    {
        _ropeText.text = "Rope Magnitude: " + _weightJoint.currentForce.magnitude;
    }
}
