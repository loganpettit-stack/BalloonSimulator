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
    public Rigidbody2D weightHook;
    public GameObject target;
    public int _numSegments; //number of segments in the chain of links
    public float displacement;

    void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody2D rbprev = weightHook.GetComponent<Rigidbody2D>(); //the starting point of the chain

        for (int i = 1; i <= _numSegments; i++)
        {
            GameObject currentLink = Instantiate(_link) as GameObject; //Create a new link from the prefab
            HingeJoint2D joint = currentLink.GetComponent<HingeJoint2D>(); //grab the joint from the prefab
            joint.connectedBody = rbprev; //set the link the new link is connected to, to the body before it

            if (i == _numSegments)
            {
                //we are on the final chain link, so we have to connect the destination to the last link
                HingeJoint2D targetjoint = target.AddComponent<HingeJoint2D>();
                targetjoint.autoConfigureConnectedAnchor = false;
                targetjoint.connectedBody = rbprev;
                targetjoint.anchor = Vector2.zero;
                targetjoint.connectedAnchor = new Vector2(0f, displacement);
            }
            else
            {
                rbprev = currentLink.GetComponent<Rigidbody2D>(); //Set the last link as the current link so the next iteration can hook onto it
            }
        }
    }
}
