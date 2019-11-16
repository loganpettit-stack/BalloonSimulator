/* gm_uislidehook.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Old, deprecated legacy code
 * 
 */

using System;
using UnityEngine;

[Obsolete("Should only be used for testing purposes", false)]
public class gm_uislidehook : MonoBehaviour
{
    public float _sizeScaleWeight = 1.0f;
    private GameObject _balloonInstanceRef;

    void Start()
    {
        _balloonInstanceRef = GameObject.FindGameObjectWithTag("Balloon");
    }

    public void resizeBalloon(float scale)
    {
        float newScale = _sizeScaleWeight * scale;
        _balloonInstanceRef.GetComponent<Transform>().localScale = new Vector3(newScale, newScale, newScale);
    }
}
