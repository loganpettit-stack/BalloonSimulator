using UnityEngine;

public class camera_smoothfollow : MonoBehaviour
{
    public Transform _target;

    public void Update()
    {
        if (Mathf.Abs(_target.position.x) < 4.75f)
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _target.position.x - transform.position.x - 3, .2f), transform.position.y, transform.position.z);
    }
}
