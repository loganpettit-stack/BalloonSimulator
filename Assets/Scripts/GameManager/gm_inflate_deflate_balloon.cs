using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gm_inflate_deflate_balloon : MonoBehaviour
{
    private JSONconfig _configuration;
    private float inflateIncrement;
    private float deflateIncrement;
    private gm_slidebarhandler sliderHandler;
    private gm_uiValuesUpdate uiUpdate;
    public GameObject _gameManager;
    public Slider _radSlider;

    // Start is called before the first frame update
    void Start()
    {
    
        _balloon = GameObject.Find("ROOT/BALLOON");
        _configuration = _gameManager.GetComponent<JSONconfig>();
        inflateIncrement = _configuration.loadedConfig.inflateIncrement;
        deflateIncrement = _configuration.loadedConfig.deflateIncrement;
        sliderHandler = _gameManager.GetComponent<gm_slidebarhandler>();
        uiUpdate = _gameManager.GetComponent<gm_uiValuesUpdate>();
    }

    public void increment()
    {
        _radSlider.value = _radSlider.value + inflateIncrement;
        sliderHandler.RadiusSliderChanged();
        uiUpdate.updateUI();
    }
    
    public void decrement()
    {
        _radSlider.value = _radSlider.value - deflateIncrement;
        sliderHandler.RadiusSliderChanged();
        uiUpdate.updateUI();
    }


}
