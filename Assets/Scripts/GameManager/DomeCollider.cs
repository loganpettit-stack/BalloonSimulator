/* DomeCollider.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Adds collider to prevent rope from exceeding max distance
 * 
 */
using UnityEngine;

public class DomeCollider : MonoBehaviour
{
    Transform _balloon; //balloon reference
    /// <summary>
    /// Grabs balloon gameobject and gets current object's sprite renderer
    /// </summary>
    void Start()
    {
        _balloon = GameObject.Find("ROOT/BALLOON").transform;

        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().enabled = false;
    }

    /// <summary>
    /// Scale dome with balloon size
    /// </summary>
    void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.one * 2.4f, Vector3.one * 8f, (_balloon.localScale.x - 0.5f) / 3.5f);
    }
}
