/* rope_charmer.cs
 * 11.18.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Adds bounds for balloon and resets balloon's position after no force horizontal
 * 
 */

using UnityEngine;

public class rope_restrictballmovement : MonoBehaviour
{
    public Transform _balloon; //Balloon transform reference
    public ConstantForce2D _balloonForce;
    public Rigidbody2D _balloonRigidbody;
    public float[] bounds = new float[] { -6.5f, 6.5f, 0f, 6.5f }; //Boundingbox for balloon (-x, +x, -y, +y)
    public float _centralForce;
    public float _rotStrength;

    // Update is called once per frame
    void Update()
    {
        float clampedX = Mathf.Clamp(_balloon.position.x, bounds[0], bounds[1]);
        float clampedY = Mathf.Clamp(_balloon.position.y, bounds[2], bounds[3]);

        _balloon.position = new Vector3(clampedX, clampedY, _balloon.position.z);
    }

    private void FixedUpdate()
    {
        //Forces balloon to center position
        if (_balloonForce.force.x == 0)
        {
            _balloonRigidbody.AddForce((new Vector3(0, _balloon.transform.position.y, _balloon.transform.position.z) - _balloon.transform.position) * _centralForce);
            _balloon.rotation = Quaternion.Euler(Vector3.Lerp(_balloon.rotation.eulerAngles, Vector3.zero, Time.deltaTime));
        }
        else
        {
            _balloon.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(_balloon.rotation.z, (180 / Mathf.PI) * Mathf.Asin((transform.position.x - _balloon.position.x) / (Mathf.Sqrt(Mathf.Pow(transform.position.x - _balloon.position.x, 2) + Mathf.Pow(transform.position.y - _balloon.position.y, 2)))), _rotStrength)));
        }
    }
}
