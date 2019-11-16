using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapShotManager : MonoBehaviour
{
    //    /Exports
    static int screenShotCounter = 0;
    public bool capture;
    Camera graphCamera;
    string directoryName;
    RenderTexture tempRT;
    Text messageText;
    float messageTimeStamp;

    void Start()
    {
        int directoryNumber = 0;

        while (Directory.Exists("Exports/ScreenShots" + directoryNumber.ToString()))
            directoryNumber++;

        directoryName = "Exports/ScreenShots" + directoryNumber.ToString();

        Directory.CreateDirectory(directoryName);

        graphCamera = GetComponent<Camera>();

        messageText = GameObject.Find("ROOT/UI/CPANEL_LEFT/CPANEL_BOTTOM/SCREENSHOT_MESSAGE").GetComponent<Text>();
        messageText.enabled = false;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad - messageTimeStamp > 2)
            messageText.enabled = false;
    }

   void LateUpdate()
    {
       if(capture)
       {
           int sqr = 1024;
           capture = false;
           // the 24 can be 0,16,24, formats like
           // RenderTextureFormat.Default, ARGB32 etc.
           tempRT = new RenderTexture(1024, 1024, 24);
           RenderTexture target = graphCamera.targetTexture;
           graphCamera.targetTexture = tempRT;
           graphCamera.Render();
           RenderTexture.active = tempRT;
           Texture2D virtualPhoto =
               new Texture2D(sqr, sqr, TextureFormat.RGB24, false);
           // false, meaning no need for mipmaps
           virtualPhoto.ReadPixels(new Rect(0, 0, sqr, sqr), 0, 0);
           RenderTexture.active = null; //can help avoid errors 
           graphCamera.targetTexture = target;
           Destroy(tempRT);
           byte[] bytes;
           bytes = virtualPhoto.EncodeToPNG();
           System.IO.File.WriteAllBytes(
              directoryName + "/" + screenShotCounter.ToString() + ".png", bytes);
           messageText.enabled = true;
           messageText.text = "Graph Saved to " + directoryName + "/" + screenShotCounter.ToString() + ".png";
           messageTimeStamp = Time.timeSinceLevelLoad;
           screenShotCounter++;
       }
    }

   public void CreateScreenShot()
    {
        capture = true;
    }
}
