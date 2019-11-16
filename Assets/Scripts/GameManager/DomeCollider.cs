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

    // Start is called before the first frame update
    void Start()
    {
        _balloon = GameObject.Find("ROOT/BALLOON").transform;

        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.one * 2.4f, Vector3.one * 8f, (_balloon.localScale.x - 0.5f) / 3.5f);
    }
}
