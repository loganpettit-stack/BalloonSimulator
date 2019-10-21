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
    public GameObject _link; //rope link
    public int _numSegments; //number of segments in the chain of links

    void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody rbprev = this.GetComponent<Rigidbody>(); //the starting point of the chain

        for (int i = 1; i <= _numSegments; i++)
        {
            GameObject currentLink = Instantiate(_link) as GameObject; //Create a new link from the prefab
            ConfigurableJoint joint = currentLink.GetComponent<ConfigurableJoint>(); //grab the joint from the prefab
            joint.connectedBody = rbprev; //set the link the new link is connected to, to the body before it

            if (i == _numSegments)
            {
                //we are on the final chain link, so we have to connect the destination to the last link
                GameObject.FindGameObjectWithTag("Destination").GetComponent<ConfigurableJoint>().connectedBody = currentLink.GetComponent<Rigidbody>();
            }
            else
            {
                rbprev = currentLink.GetComponent<Rigidbody>(); //Set the last link as the current link so the next iteration can hook onto it
            }
        }
    }
}
