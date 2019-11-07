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
    private GameObject _balloon;
    private Vector3 _targetScale;
    public float _speed;
    public float radius;

    

    public void Start()
    {
        _balloon = GameObject.Find("ROOT/BALLOON");
        _radiusSlider.maxValue = _configuration.loadedConfig.maxRadius;
        _radiusSlider.minValue = _configuration.loadedConfig.minRadius;

        string minString = _radiusSlider.minValue.ToString() + " cm";
        string maxString = _radiusSlider.maxValue.ToString() + " cm";

        _textMin.text = minString;
        _textMax.text = maxString;

        _radiusSlider.value = _radiusSlider.minValue;
    }

    public void Update()
    {
        _balloon.transform.localScale = Vector3.Lerp(_balloon.transform.localScale, _targetScale, _speed * Time.deltaTime);
    }

    public void RadiusSliderChanged()
    {

        float value = _radiusSlider.value;
        radius = value / 100;

        Debug.Log(value);

        /*Get slider value and add units, display to screen*/
        string valueWithUnit = value + " cm";
        _sliderValue.text = valueWithUnit;
        _targetScale = new Vector3(radius, radius, (float)0.75);
    }

    public void RadiusSliderChangedByIncrement()
    {

        float value = _radiusSlider.value;
        radius = value / 100;

        Debug.Log(value);

        /*Get slider value and add units, display to screen*/
        string valueWithUnit = value + " cm";
        _sliderValue.text = valueWithUnit;
        _targetScale = new Vector3(radius, radius, (float)0.75);
    }


}
