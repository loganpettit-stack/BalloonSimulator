using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gm_slidebarhandler : MonoBehaviour
{

    public Slider _radiusSlider;
    public Text _sliderValue;
    public Text _textMax;
    public Text _textMin;
    public JSONconfig _configuration;


    public void Start()
    {
        _radiusSlider.maxValue = _configuration.loadedConfig.maxRadius;
        _radiusSlider.minValue = _configuration.loadedConfig.minRadius;

        string minString = _radiusSlider.minValue.ToString() + " cm";
        string maxString = _radiusSlider.maxValue.ToString() + " cm";

        _textMin.text = minString;
        _textMax.text = maxString;

        _radiusSlider.value = _radiusSlider.minValue;
    }

    public void RadiusSliderChanged()
    {
        float value = _radiusSlider.value;
        float radius = value / 100;

        Debug.Log(value);

        /*Get slider value and add units, display to screen*/
        string valueWithUnit = value + " cm";
        _sliderValue.text = valueWithUnit;

        GameObject balloon = GameObject.Find("ROOT/BALLOON");
        balloon.transform.localScale = new Vector3(radius, radius, (float)0.75);
    }

}
