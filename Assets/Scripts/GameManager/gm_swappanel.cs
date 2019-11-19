/* gm_swappanel.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Swaps panels in betweenn wind and radius panels
 * 
 */

using UnityEngine;

public class gm_swappanel : MonoBehaviour
{
    public JSONconfig config;
    private bool radiusSlider;
    private bool inflateDeflateButton;

    public GameObject _radiusPanelParent; //radius parent panel
    public GameObject _windPanelParent; //wind parent panel
    public GameObject _radiusSliderUI; // radius slider object
    public GameObject _inflateDeflatePanel; // inflate deflate buttons

    void Start()
    {
        radiusSlider = config.loadedConfig.radiusSlider;
        inflateDeflateButton = config.loadedConfig.inflateDeflateButton;
    }
    /// <summary>
    /// Enables radius panel, hides wind panel
    /// </summary>
    public void SetRadiusPanelEnabled()
    {
        _radiusPanelParent.SetActive(true);
        if (radiusSlider == true && inflateDeflateButton == true)
        {
            _radiusPanelParent.SetActive(true);
            _windPanelParent.SetActive(false);
        } 
        else if (radiusSlider == true && inflateDeflateButton == false)
        {
            _radiusSliderUI.SetActive(true);
            _inflateDeflatePanel.SetActive(false);
            _windPanelParent.SetActive(false);
        } 
        else if (radiusSlider == false && inflateDeflateButton == true)
        {
            _radiusSliderUI.SetActive(false);
            _inflateDeflatePanel.SetActive(true);
            _windPanelParent.SetActive(false);
        } 
        else
        {
            _radiusPanelParent.SetActive(false);
            _windPanelParent.SetActive(false);
        }
    }

    /// <summary>
    /// Enables wind panel, hides radius panel
    /// </summary>
    public void SetWindPanelEnabled()
    {
        _radiusPanelParent.SetActive(false);
        _windPanelParent.SetActive(true);
    }
}
