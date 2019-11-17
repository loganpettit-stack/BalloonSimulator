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
        int X_AXIS = _dropdownX.value;
        int Y_AXIS = _dropdownY.value;



    }
}
