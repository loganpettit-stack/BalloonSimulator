/* ColorPicker.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Script smoothly follows the balloon with an offset and buffer
 * 
 */
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    Renderer _balloon; //Balloon renderer
    public Vector3 _worldPos; //Position of color picker in world

    void Start()
    {
        _balloon = GameObject.Find("ROOT/BALLOON").GetComponent<Renderer>(); //pick up the renderer off the balloon
    }


    void OnGUI()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(_worldPos.x * Screen.width, _worldPos.y * Screen.height, 10)) + Vector3.forward * -2f; //center the color picker
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //on left click
        {
            RaycastHit raycastHit; //raycast reference

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //perform raycasst

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == transform) //make sure we hit the right collider / object
                {
                    Renderer renderer = raycastHit.collider.GetComponent<MeshRenderer>();
                    Texture2D texture2D = renderer.material.mainTexture as Texture2D;
                    Vector2 pCoord = raycastHit.textureCoord;
                    pCoord.x *= texture2D.width;
                    pCoord.y *= texture2D.height;

                    Vector2 tiling = renderer.material.mainTextureScale;
                    Color color = texture2D.GetPixel(Mathf.FloorToInt(pCoord.x * tiling.x), Mathf.FloorToInt(pCoord.y * tiling.y));

                    _balloon.material.color = color;
                }
            }
        }
    }
}
