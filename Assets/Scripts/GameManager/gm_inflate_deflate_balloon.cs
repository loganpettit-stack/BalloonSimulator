/* gm_inflate_deflate_balloon.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Defines properties of the balloon and contains some of the calculations needed for operations
 * 
 */
using UnityEngine;
using UnityEngine.UI;

public class gm_inflate_deflate_balloon : MonoBehaviour
{
    private JSONconfig _configuration; //config refrence
    private float _inflateIncrement; 
    private float _deflateIncrement;
    private gm_slidebarhandler _sliderHandler; //script reference
    private gm_uiValuesUpdate _uiUpdate; //script reference
    public GameObject _gameManager; //gamemanager reference
    public Slider _radSlider; //slider reference

    // Start is called before the first frame update
    void Start()
    {
        _configuration = _gameManager.GetComponent<JSONconfig>();
        _inflateIncrement = _configuration.loadedConfig.inflateIncrement;
        _deflateIncrement = _configuration.loadedConfig.deflateIncrement;
        _sliderHandler = _gameManager.GetComponent<gm_slidebarhandler>();
        _uiUpdate = _gameManager.GetComponent<gm_uiValuesUpdate>();
    }

    public void increment()
    {
        _radSlider.value = _radSlider.value + _inflateIncrement;
        _sliderHandler.RadiusSliderChanged();
        _uiUpdate.updateUI();
    }

    public void decrement()
    {
        _radSlider.value = _radSlider.value - _deflateIncrement;
        _sliderHandler.RadiusSliderChanged();
        _uiUpdate.updateUI();
    }


}
