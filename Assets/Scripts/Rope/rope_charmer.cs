/* rope_charmer.cs
 * 11.18.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Removes some of the of the unstable physics properties of the ropes by reducing the collision and interta tensors
 * 
 */

using UnityEngine;

public class rope_charmer : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.centerOfMass = Vector2.zero;
        rb.inertia = 1.0f;
        //rb.inertiaTensor = new Vector3(1.0f, 2.0f, 3.0f);
        //rb.inertiaTensorRotation = new Quaternion(0.1f, 0.1f, 0.1f, 0.1f);
    }
}
