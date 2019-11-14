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
    private bool magnifyButton;
    private bool graph;
    private bool dataBox;
    //public GameObject colorPanel;
    public GameObject radiusPanel;
    public GameObject radiusButton;
    public GameObject windPanel;
    public GameObject windButton;
    public GameObject radiusWindPanel;
    public GameObject sliderPanel;
    public GameObject inflateDeflatePanel;
    public GameObject recordBtn;
    public GameObject magnifyBtn;
    public GameObject graphUI;
    public GameObject graphPanel;
    public GameObject dataPanel;
    public GameObject leftPanel;
    public GameObject rightPanel;

    // Start is called before the first frame update
    void Start()
    {
        //colorWheel = GameObject.Find("");
        radiusPanel = GameObject.Find("PANEL_RADIUS");
        radiusButton = GameObject.Find("BTN_ACTIVATE_RADIUS_PANEL");
        windPanel = GameObject.Find("PANEL_WIND");
        windButton = GameObject.Find("BTN_ACTIVATE_WIND_PANEL");
        radiusWindPanel = GameObject.Find("CPANEL_TOP");
        sliderPanel = GameObject.Find("CPANEL_BOTTOM");
        inflateDeflatePanel = GameObject.Find("CPANEL_INFLATE_DEFLATE_BUTTON");
        recordBtn = GameObject.Find("BTN_RECORD");
        magnifyBtn = GameObject.Find("BTN_MAGNIFY");
        graphUI = GameObject.Find("GRAPH");
        graphPanel = GameObject.Find("CPANEL_BOTTOM");
        dataPanel = GameObject.Find("CPANEL_TOP");
        leftPanel = GameObject.Find("CPANEL_LEFT");
        rightPanel = GameObject.Find("CPANEL_RIGHT");

        colorWheel = config.loadedConfig.colorWheel;
        radiusSlider = config.loadedConfig.radiusSlider;
        windSlider = config.loadedConfig.windSlider;
        inflateDeflateButton = config.loadedConfig.inflateDeflateButton;
        recordButton = config.loadedConfig.recordButton;
        magnifyButton = config.loadedConfig.magnifyButton;
        graph = config.loadedConfig.graph;
        dataBox = config.loadedConfig.dataBox;

        //if (colorWheel == true)
        //{
        //    colorPanel.SetActive(true);
        //} else
        //{
        //    colorPanel.SetActive(false);
        //}

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
            radiusWindPanel.SetActive(false);
            //radiusButton.SetActive(true);
            //windPanel.SetActive(false);
            //windButton.SetActive(false);
        } 
        else if (radiusSlider == false && windSlider == true)
        {
            //radiusPanel.SetActive(false);
            //radiusButton.SetActive(false);
            windPanel.SetActive(true);
            //windButton.SetActive(true);
            radiusWindPanel.SetActive(false);
        } 
        else
        {
            //radiusPanel.SetActive(false);
            //radiusButton.SetActive(false);
            //windPanel.SetActive(false);
            //windButton.SetActive(false);
            radiusWindPanel.SetActive(false);
            sliderPanel.SetActive(false);
        }

        if (inflateDeflateButton == true)
        {
            inflateDeflatePanel.SetActive(true);
        } 
        else
        {
            inflateDeflatePanel.SetActive(false);
        }

        if (recordButton == true && magnifyButton == true)
        {
            graphPanel.SetActive(true);
        } else if (recordButton == true && magnifyButton == false)
        {
            graphUI.SetActive(true);
            recordBtn.SetActive(true);
            magnifyBtn.SetActive(false);
        } else if (recordButton == false && magnifyButton == true)
        {
            graphUI.SetActive(true);
            recordBtn.SetActive(false);
            magnifyBtn.SetActive(true);
        } else if (recordButton == false && magnifyButton == false)
        {
            graphUI.SetActive(true);
            recordBtn.SetActive(false);
            magnifyBtn.SetActive(false);
        }

        if (recordButton == false && magnifyButton == false && graph == false && dataBox == false)
        {
            leftPanel.SetActive(false);
        }
        if (dataBox == true && recordButton == false && magnifyButton == false)
        {
            dataPanel.SetActive(true);
            graphPanel.SetActive(false);
        }

        if (dataBox == false)
        {
            dataPanel.SetActive(false);
        }
       
    }
}
