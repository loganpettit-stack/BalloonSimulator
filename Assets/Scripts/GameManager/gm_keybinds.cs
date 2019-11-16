/* gm_keybinds.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Handles keybinds, including game exit
 * 
 */
using UnityEngine;

public class gm_keybinds : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
