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

    public GameObject _graphTarget, //parent of graph
        _datapointPrefab; //what to make graph out of

    public dataCollect _dataSource; //data source script

    private float BOUND_L, //calculated bound
        BOUND_T,
        BOUND_R, 
        BOUND_B;

    private float BOUND_HEIGHT, //height bound and width bounds for display
        BOUND_WIDTH;

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

    }
}
