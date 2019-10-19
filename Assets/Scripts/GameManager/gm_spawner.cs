/* gm_uislidehook.cs
 * 11.18.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Instantiates prefabs at runtime
 */

using UnityEngine;

public class gm_spawner : MonoBehaviour
{
    public GameObject _balloonPrefabRef;

    void Awake()
    {
        Instantiate(_balloonPrefabRef);
    }

}
