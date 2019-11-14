using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyPanel : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
