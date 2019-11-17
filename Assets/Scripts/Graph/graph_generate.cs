using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class graph_generate : MonoBehaviour
{
    public Transform _ANCHOR_TL,
        _ANCHOR_TR, 
        _ANCHOR_BL, 
        _ANCHOR_BR;

    public Dropdown _dropdownX,
        _dropdownY;

    public GameObject _graphTarget, 
        _datapointPrefab;

    public dataCollect _dataSource;

    private float BOUND_L, 
        BOUND_T,
        BOUND_R, 
        BOUND_B;

    private float BOUND_HEIGHT, 
        BOUND_WIDTH;

    void Start()
    {
        BOUND_L = Mathf.Max(_ANCHOR_BL.position.z, _ANCHOR_TL.position.z);
        BOUND_T = Mathf.Max(_ANCHOR_TL.position.y, _ANCHOR_TR.position.y);
        BOUND_R = Mathf.Min(_ANCHOR_TR.position.z, _ANCHOR_BR.position.z);
        BOUND_B = Mathf.Min(_ANCHOR_BL.position.y, _ANCHOR_BR.position.y);

        BOUND_HEIGHT = BOUND_T - BOUND_B;
        BOUND_WIDTH = BOUND_L - BOUND_R;
    }

    public void RegenGraph()
    {
        int _children = _graphTarget.transform.childCount;
        for (int i = _children - 1; i > 0; i--)
        {
            Destroy(_graphTarget.transform.GetChild(i).gameObject);
        }

        int X_AXIS = _dropdownX.value;
        int Y_AXIS = _dropdownY.value;

        ArrayList values = _dataSource.getDataSet();

        float X_MAX = 0;
        float Y_MAX = 0;

        foreach (BalloonData item in values)
        {
            float[] itemData = item.GetDataArray();
            if (itemData[X_AXIS] > X_MAX)
                X_MAX = itemData[X_AXIS];
            if (itemData[Y_AXIS] > Y_MAX)
                Y_MAX = itemData[Y_AXIS];
        }

        float GRAPH_SCALE_X = X_MAX / BOUND_WIDTH;
        float GRAPH_SCALE_Y = Y_MAX / BOUND_HEIGHT;

        foreach (BalloonData item in values)
        {
            float[] itemData = item.GetDataArray();
            GameObject point = Instantiate(_datapointPrefab) as GameObject;
            point.transform.parent = _graphTarget.transform;
            point.transform.localPosition = new Vector3(.3f, itemData[Y_AXIS] * GRAPH_SCALE_Y, itemData[X_AXIS] * GRAPH_SCALE_X);
        }

    }
}
