using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gm_swappanel : MonoBehaviour
{
    public GameObject _radiusPanelParent;
    public GameObject _windPanelParent;


    public void SetRadiusPanelEnabled()
    {
        _radiusPanelParent.SetActive(true);
        _windPanelParent.SetActive(false);
    }

    public void SetWindPanelEnabled()
    {
        _radiusPanelParent.SetActive(false);
        _windPanelParent.SetActive(true);
    }
}
