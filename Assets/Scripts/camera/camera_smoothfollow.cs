/* camera_smoothfollow.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Script smoothly follows the balloon with an offset and buffer
 * 
 */

using UnityEngine;

public class camera_smoothfollow : MonoBehaviour
{
    public Transform _target; //Target of camera follow, 

    /// <summary>
    /// Moves the camera smoothly if camera exceeds certain X distance from the balloon
    /// </summary>
    public void Update() 
    {
        if (Mathf.Abs(_target.position.x) < 4.75f) //Buffer zone
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _target.position.x - transform.position.x - 3, .2f), transform.position.y, transform.position.z);
    }
}
