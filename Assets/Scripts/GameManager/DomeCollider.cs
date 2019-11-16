using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeCollider : MonoBehaviour
{
    Transform balloon;

    // Start is called before the first frame update
    void Start()
    {
        balloon = GameObject.Find("ROOT/BALLOON").transform;
     
        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.one * 2.4f, Vector3.one * 8f, (balloon.localScale.x - 0.5f) / 3.5f);
    }
}
