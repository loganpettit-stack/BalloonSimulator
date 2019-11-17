/* MagnifyPanel.cs
 * 11.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Enables and disables the magnify context menu
 */

using UnityEngine;

public class MagnifyPanel : MonoBehaviour
{
    /// <summary>
    /// Hides the magnify pane by default
    /// </summary>
    void Start()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Switches magnify panel between on and off as a toggle switch
    /// </summary>
    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
