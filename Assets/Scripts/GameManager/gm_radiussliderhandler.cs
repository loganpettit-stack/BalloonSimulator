using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gm_radiussliderhandler : MonoBehaviour
{
    public Slider _radiusSlider;
    public Text _sliderValue;
    public Text _textMax;
    public Text _textMin;


    //public JSONconfig _configuration;

    public void Start()
    {
        //_radiusSlider.maxValue = _configuration.UI.maxSlidervalue;
        //_radiusSlider.minValue = _configuration.UI.minSlidervalue;
        //_textMin.text = _configuration.UI.minSlidervalue.toString();
        //_textMax.text = _configuration.UI.maxSlidervalue.toString();

        _radiusSlider.value = _radiusSlider.minValue;


    }

    public void RadiusSliderChanged()
    {
        /*Output slider value to console*/
        Debug.Log(_radiusSlider.value);

        /**/
        string valueWithUnit = _radiusSlider.value.ToString() + " cm";
        _sliderValue.text = valueWithUnit;
   }

}
