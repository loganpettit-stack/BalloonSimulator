using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    Renderer balloon;
    public Vector3 worldPos;

    // Start is called before the first frame update
    void Start()
    {
        balloon = GameObject.Find("ROOT/BALLOON").GetComponent<Renderer>();
        
    }


    void OnGUI()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(worldPos.x * Screen.width, worldPos.y * Screen.height, 10)) + Vector3.forward * -2f;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButton(0))
        {
            RaycastHit raycastHit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == transform)
                {
                    Renderer renderer = raycastHit.collider.GetComponent<MeshRenderer>();
                    Texture2D texture2D = renderer.material.mainTexture as Texture2D;
                    Vector2 pCoord = raycastHit.textureCoord;
                    pCoord.x *= texture2D.width;
                    pCoord.y *= texture2D.height;

                    Vector2 tiling = renderer.material.mainTextureScale;
                    Color color = texture2D.GetPixel(Mathf.FloorToInt(pCoord.x * tiling.x), Mathf.FloorToInt(pCoord.y * tiling.y));

                    balloon.material.color = color;
                }
            }
        }
    }
}
