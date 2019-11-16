/* MagnifyPanel.cs
 * 11.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Enables and disables the magnify context menu
 */

using UnityEngine;

public class MagnifyPanel : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
