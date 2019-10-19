/* rope_generaterope.cs
 * 11.18.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Generates a series of linked hinges using a _link model, creating _numSegments many segments between the source,
 * the entity this is attached to, and the destination which is tagged as "DESTINATION" under unity tags.
 */

using UnityEngine;

public class rope_generaterope : MonoBehaviour
{
    public GameObject _link;
    public int _numSegments;

    void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody rbprev = this.GetComponent<Rigidbody>();

        for (int i = 1; i <= _numSegments; i++)
        {
            GameObject currentLink = Instantiate(_link) as GameObject;
            ConfigurableJoint joint = currentLink.GetComponent<ConfigurableJoint>();
            joint.connectedBody = rbprev;

            if (i == _numSegments)
            {
                GameObject.FindGameObjectWithTag("Destination").GetComponent<ConfigurableJoint>().connectedBody = currentLink.GetComponent<Rigidbody>();
            }
            else
            {
                rbprev = currentLink.GetComponent<Rigidbody>();
            }
        }
    }
}
