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
    public GameObject _radiusPanelParent; //radius parent panel
    public GameObject _windPanelParent; //wind parent panel


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
