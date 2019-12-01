/*configUIcontroller.cs
 * 11.14.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: This script controls which UI components are enabled or
 * disabled. It will obtain boolean values from the config object and
 * set active game objects based on it.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configUIcontroller : MonoBehaviour
{
    public JSONconfig config;
    // booleans declared to store values from config file
    private bool colorWheel;
    private bool radiusSlider;
    private bool windSlider;
    private bool inflateDeflateButton;
    private bool recordButton;
    private bool graph;
    private bool dataBox;
    // referenced game objects for enabling and disabling
    public GameObject colorPanel;
    public GameObject radiusPanel;
    public GameObject windPanel;
    public GameObject radiusWindPanel;
    public GameObject radiusSliderUI;
    public GameObject sliderPanel;
    public GameObject inflateDeflatePanel;
    public GameObject recordBtn;
    public GameObject magnifyBtn;
    public GameObject exportBtn;
    public GameObject graphPanel;
    public GameObject dataPanel;
    public GameObject leftPanel;
    public GameObject rightPanel;

    // Start is called before the first frame update
    void Start()
    {
        // setting game objects to corresponding UI components
        colorPanel = GameObject.Find("COLOR_PICKER");
        radiusPanel = GameObject.Find("PANEL_RADIUS");
        windPanel = GameObject.Find("PANEL_WIND");
        radiusWindPanel = GameObject.Find("CPANEL_TOP_R");
        radiusSliderUI = GameObject.Find("SLIDER_RADIUS");
        sliderPanel = GameObject.Find("CPANEL_BOTTOM_R");
        inflateDeflatePanel = GameObject.Find("CPANEL_INFLATE_DEFLATE_BUTTON");
        exportBtn = GameObject.Find("BTN_EXPORT");
        recordBtn = GameObject.Find("BTN_RECORD");
        magnifyBtn = GameObject.Find("BTN_EXAMINE");
        graphPanel = GameObject.Find("CPANEL_BOTTOM_L");
        dataPanel = GameObject.Find("CPANEL_TOP_L");
        leftPanel = GameObject.Find("CPANEL_LEFT");
        rightPanel = GameObject.Find("CPANEL_RIGHT");

        // setting boolean values from config file
        colorWheel = config.loadedConfig.colorWheel;
        radiusSlider = config.loadedConfig.radiusSlider;
        windSlider = config.loadedConfig.windSlider;
        inflateDeflateButton = config.loadedConfig.inflateDeflateButton;
        recordButton = config.loadedConfig.recordButton;
        graph = config.loadedConfig.graph;
        dataBox = config.loadedConfig.dataBox;

        // color wheel UI control
        if (colorWheel == true)
        {
            colorPanel.SetActive(true);
        }
        else
        {
            colorPanel.SetActive(false);
        }

        // right panel UI control
        if (radiusSlider == true && windSlider == true) // manages radius slider, wind slider, and respective switches
        {
            radiusSliderUI.SetActive(true);
            windPanel.SetActive(false);
            radiusWindPanel.SetActive(true);

            if (inflateDeflateButton == true)
            {
                inflateDeflatePanel.SetActive(true);
            } 
            else if (inflateDeflateButton == false)
            {
                inflateDeflatePanel.SetActive(false);
            }
        }
        else if (radiusSlider == true && windSlider == false)
        {
            if (inflateDeflateButton == true)
            {
                radiusSliderUI.SetActive(true);
                inflateDeflatePanel.SetActive(true);
                radiusWindPanel.SetActive(false);
                windPanel.SetActive(false);
            }
            else
            {
                radiusSliderUI.SetActive(true);
                inflateDeflatePanel.SetActive(false);
                radiusWindPanel.SetActive(false);
                windPanel.SetActive(false);
            }
        } 
        else if (radiusSlider == false && windSlider == true)
        {
            if (inflateDeflateButton == true)
            {
                radiusSliderUI.SetActive(false);
                inflateDeflatePanel.SetActive(true);
                radiusWindPanel.SetActive(true);
                windPanel.SetActive(false);
            }
            else
            {
                radiusPanel.SetActive(false);
                radiusWindPanel.SetActive(false);
                windPanel.SetActive(true);
            }
        } 
        else if (radiusSlider == false && windSlider == false)
        {
            if (inflateDeflateButton == true)
            {
                radiusSliderUI.SetActive(false);
                inflateDeflatePanel.SetActive(true);
                radiusWindPanel.SetActive(false);
                windPanel.SetActive(false);
            }
            else
            {
                rightPanel.SetActive(false);
            }
        }

        // left panel UI control

        if (graph == true && recordButton == true) // enables graph, record, magnify ... disables export
        {
            recordBtn.SetActive(true);
            magnifyBtn.SetActive(true);
            exportBtn.SetActive(false);
        }
        else if (graph == false && recordButton == true) // disables graph, record, magnify ... enables export
        {
            recordBtn.SetActive(false);
            magnifyBtn.SetActive(false);
            exportBtn.SetActive(true);
        }

        // disables entire graph panel
        if (recordButton == false)
        {
            graphPanel.SetActive(false);
        }

        // enables/disables data box
        if (dataBox == true)
        {
            dataPanel.SetActive(true);
        }
        else
        {
            dataPanel.SetActive(false);
        }

        // enables/disables entire left panel
        if (graph == false && dataBox == false && recordButton == false)
        {
            leftPanel.SetActive(false);
        }
       
    }
}
