using UnityEngine;

public class gm_spawner : MonoBehaviour
{
    public GameObject _balloonPrefabRef;

    void Awake()
    {
       (Instantiate(_balloonPrefabRef) as GameObject).name = "BalloonInstance";
    }

}
