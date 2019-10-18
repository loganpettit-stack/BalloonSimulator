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
            HingeJoint joint = currentLink.GetComponent<HingeJoint>();
            joint.connectedBody = rbprev;

            if (i == _numSegments)
                GameObject.FindGameObjectWithTag("Destination").GetComponent<HingeJoint>().connectedBody = currentLink.GetComponent<Rigidbody>();
            else
                rbprev = currentLink.GetComponent<Rigidbody>();
        }
    }
}
