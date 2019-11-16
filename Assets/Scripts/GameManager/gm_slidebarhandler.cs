/* gm_slidebarhandler.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Handles slider changes for radius slider and affects balloon
 * 
 */
using UnityEngine;
using UnityEngine.UI;

public class gm_slidebarhandler : MonoBehaviour
{

    public Slider _radiusSlider; //slider reference
    public Text _sliderValue; //text reference
    public Text _textMax; //text reference 
    public Text _textMin; //text reference
    public JSONconfig _configuration; //configuration reference
    private GameObject _balloon; //balloon object refrence
    private Vector3 _targetScale;
    public float _speed;
    public float _radius;



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
        _radius = value / 100;

        /*Get slider value and add units, display to screen*/
        string valueWithUnit = value + " cm";
        _sliderValue.text = valueWithUnit;
        _targetScale = new Vector3(_radius, _radius, (float)0.75);
    }
}
