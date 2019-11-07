/* gm_updatedatbbox.cs
 * 11.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Interface to update the values on screen displayed in the data box
 */

using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class gm_updatedatbbox : MonoBehaviour
{
    /* Public Variables */
    public Text _radiusText;
    public Text _surfaceareaText;
    public Text _volumeText;
    public Text _forceText;

    public float _lerpSpeed;

    /* Private, but editor visible variables */
    [SerializeField]
    private FieldValue _radiusValue;
    [SerializeField]
    private FieldValue _surfaceareaValue;
    [SerializeField]
    private FieldValue _volumeValue;
    [SerializeField]
    private FieldValue _forceValue;

    /* Setters for DataBox Values */
    public void SetRadiusValue(float value)
    {
        _radiusValue._realValue = value;
    }

    public void SetSurfaceAreaValue(float value)
    {
        _surfaceareaValue._realValue = value;
    }

    public void SetVolumeValue(float value)
    {
        _volumeValue._realValue = value;
    }

    public void SetForceValue(float value)
    {
        _forceValue._realValue = value;
    }

    /* Sets all values in a single command */
    public void SetAllValues(float radius, float surfacearea, float volume, float force)
    {
        SetRadiusValue(radius);
        SetSurfaceAreaValue(surfacearea);
        SetVolumeValue(volume);
        SetForceValue(force);
    }

    public void Start()
    {
        _radiusValue = new FieldValue("m");
        _surfaceareaValue = new FieldValue("m²");
        _volumeValue = new FieldValue("m³");
        _forceValue = new FieldValue("Nm");
    }

    /* Smooths transition between values for better user experience */
    void Update()
    {
        _radiusValue._currentValue = Mathf.Lerp(_radiusValue._currentValue, _radiusValue._realValue, _lerpSpeed);
        _surfaceareaValue._currentValue = Mathf.Lerp(_surfaceareaValue._currentValue, _surfaceareaValue._realValue, _lerpSpeed);
        _volumeValue._currentValue = Mathf.Lerp(_volumeValue._currentValue, _volumeValue._realValue, _lerpSpeed);
        _forceValue._currentValue = Mathf.Lerp(_forceValue._currentValue, _forceValue._realValue, _lerpSpeed);

        _radiusText.text = _radiusValue._currentValue.ToString("N2") + _radiusValue._units;
        _surfaceareaText.text = _surfaceareaValue._currentValue.ToString("N2") + _surfaceareaValue._units;
        _volumeText.text = _volumeValue._currentValue.ToString("N2") + _volumeValue._units;
        _forceText.text = _forceValue._currentValue.ToString("N2") + _forceValue._units;
    }
}

[System.Serializable]
public class FieldValue
{
    public string _units;
    public float _realValue;
    public float _currentValue;

    public FieldValue(string unitval)
    {
        this._units = " " + unitval;
        this._realValue = 0.0f;
        this._currentValue = 0.0f;
    }
}