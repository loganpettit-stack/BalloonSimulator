using UnityEngine;

public class gm_uislidehook : MonoBehaviour
{
    public float _sizeScaleWeight = 1.0f;
    private GameObject _balloonInstanceRef;

    void Start()
    {
        _balloonInstanceRef = GameObject.FindGameObjectWithTag("Balloon");
    }

    public void resizeBalloon(float scale)
    {
        float newScale = _sizeScaleWeight * scale;
        _balloonInstanceRef.GetComponent<Transform>().localScale = new Vector3(newScale, newScale, _balloonInstanceRef.GetComponent<Transform>().localScale.z);
    }
}
