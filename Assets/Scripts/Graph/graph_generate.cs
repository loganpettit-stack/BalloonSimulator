/* graph_generate.cs
 * 11.13.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Creates graph, redraws on update
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class graph_generate : MonoBehaviour
{
    public Transform _ANCHOR_TL, //top left anchor
        _ANCHOR_TR, //top right anchor
        _ANCHOR_BL, //bottom left anchor
        _ANCHOR_BR; //bottom right anchor

    public Dropdown _dropdownX, //x dropdown value
        _dropdownY; //y dropdown value

    public Text _xAxisLabel, _yAxisLabel; //Axis labels

    public GameObject _graphTarget,  //parent of graph
        _markerTarget,
        _datapointPrefab,  //what to make graph out of
        _marker; //side marker

    public dataCollect _dataSource; //data source script

    private float BOUND_L, //calculated bound
        BOUND_T,
        BOUND_R,
        BOUND_B;

    private float BOUND_HEIGHT, //height bound and width bounds for display
        BOUND_WIDTH;

    private string[] _scaleVals = { "m", "m²", "m³", "Nm", "kg", "m/s", "Nm" };

    /// <summary>
    /// Performs bounds calculations for the display
    /// </summary>
    void Start()
    {
        BOUND_L = Mathf.Max(_ANCHOR_BL.position.z, _ANCHOR_TL.position.z);
        BOUND_T = Mathf.Max(_ANCHOR_TL.position.y, _ANCHOR_TR.position.y);
        BOUND_R = Mathf.Min(_ANCHOR_TR.position.z, _ANCHOR_BR.position.z);
        BOUND_B = Mathf.Min(_ANCHOR_BL.position.y, _ANCHOR_BR.position.y);

        BOUND_HEIGHT = BOUND_T - BOUND_B;
        BOUND_WIDTH = BOUND_L - BOUND_R;

        GenerateMarkers();
        RegenGraph();
    }

    private void GenerateMarkers()
    {
        float MARKER_Y_INC = BOUND_HEIGHT / 10.0f;
        float MARKER_X_INC = BOUND_WIDTH / 10.0f;

        for (int inc = 0; inc <= 10; inc++)
        {
            GameObject marker = Instantiate(_marker) as GameObject;
            marker.transform.parent = _markerTarget.transform;
            marker.transform.localPosition = new Vector3(.3f, MARKER_Y_INC * inc, 0);
        }

        for (int inc = 0; inc <= 10; inc++)
        {
            GameObject marker = Instantiate(_marker) as GameObject;
            marker.transform.parent = _markerTarget.transform;
            marker.transform.localRotation = Quaternion.Euler(new Vector3(90.0f, 0, 0));
            marker.transform.localPosition = new Vector3(.3f, 0, MARKER_X_INC * inc * -1);
        }
    }


    /// <summary>
    /// Refreshes graph when called
    /// </summary>
    public void RegenGraph()
    {
        int _children = _graphTarget.transform.childCount; //remove old children if any
        for (int i = _children - 1; i > 0; i--)
        {
            Destroy(_graphTarget.transform.GetChild(i).gameObject);
        }

        int X_AXIS = _dropdownX.value; //Get what is on the X axis
        int Y_AXIS = _dropdownY.value; //Get what is on the Y axis

        ArrayList values = _dataSource.getDataSet();

        float X_MAX = 0;
        float Y_MAX = 0;

        foreach (BalloonData item in values) //Calculate max value to normalize
        {
            float[] itemData = item.GetDataArray();
            if (itemData[X_AXIS] > X_MAX)
                X_MAX = itemData[X_AXIS];
            if (itemData[Y_AXIS] > Y_MAX)
                Y_MAX = itemData[Y_AXIS];
        }

        float GRAPH_SCALE_X = BOUND_WIDTH / X_MAX; //Get scale based on the normalize
        float GRAPH_SCALE_Y = BOUND_HEIGHT / Y_MAX;

        foreach (BalloonData item in values) //print value
        {
            float[] itemData = item.GetDataArray();
            GameObject point = Instantiate(_datapointPrefab) as GameObject;
            point.transform.parent = _graphTarget.transform;
            point.transform.localPosition = new Vector3(.3f, itemData[Y_AXIS] * GRAPH_SCALE_Y, itemData[X_AXIS] * GRAPH_SCALE_X * -1);

        }

        _xAxisLabel.text = string.Format("X-Axis: (tick: {0} {1} : max: {2} {3})", (X_MAX / 10).ToString("N2"), _scaleVals[X_AXIS], (X_MAX).ToString("N2"), _scaleVals[X_AXIS]);
        _yAxisLabel.text = string.Format("Y-Axis: (tick: {0} {1} : max: {2} {3})", (Y_MAX / 10).ToString("N2"), _scaleVals[Y_AXIS], (Y_MAX).ToString("N2"), _scaleVals[Y_AXIS]);

    }
}
