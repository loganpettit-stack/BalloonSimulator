using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configUIcontroller : MonoBehaviour
{
    public JSONconfig config;
    private bool colorWheel;
    private bool radiusSlider;
    private bool windSlider;
    private bool inflateDeflateButton;
    private bool recordButton;
    private bool graph;
    private bool dataBox;
    //public GameObject colorPanel;
    public GameObject radiusPanel;
    public GameObject radiusButton;
    public GameObject windPanel;
    public GameObject windButton;
    public GameObject inflateDeflatePanel;

    // Start is called before the first frame update
    void Start()
    {
        //colorWheel = GameObject.Find("");
        radiusPanel = GameObject.Find("PANEL_RADIUS");
        radiusButton = GameObject.Find("BTN_ACTIVATE_RADIUS_PANEL");
        windPanel = GameObject.Find("PANEL_WIND");
        windButton = GameObject.Find("BTN_ACTIVATE_WIND_PANEL");
        inflateDeflatePanel = GameObject.Find("CPANEL_INFLATE_DEFLATE_BUTTON");

        colorWheel = config.loadedConfig.colorWheel;
        radiusSlider = config.loadedConfig.radiusSlider;
        windSlider = config.loadedConfig.windSlider;
        inflateDeflateButton = config.loadedConfig.inflateDeflateButton;

        if (radiusSlider == true && windSlider == true)
        {
            radiusPanel.SetActive(true);
            radiusButton.SetActive(true);
            windPanel.SetActive(false);
            windButton.SetActive(true);
        }
        else if (radiusSlider == true && windSlider == false)
        {
            radiusPanel.SetActive(true);
            radiusButton.SetActive(true);
            windPanel.SetActive(false);
            windButton.SetActive(false);
        } 
        else if (radiusSlider == false && windSlider == true)
        {
            radiusPanel.SetActive(false);
            radiusButton.SetActive(false);
            windPanel.SetActive(true);
            windButton.SetActive(true);
        } 
        else
        {
            radiusPanel.SetActive(false);
            radiusButton.SetActive(false);
            windPanel.SetActive(false);
            windButton.SetActive(false);
        }

        if (inflateDeflateButton == true)
        {
            inflateDeflatePanel.SetActive(true);
        } 
        else
        {
            inflateDeflatePanel.SetActive(false);
        }

        
    }
}
