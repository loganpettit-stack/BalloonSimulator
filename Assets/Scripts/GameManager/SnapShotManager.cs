/* SnapShotManager.cs
 * 11.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Exports screenshots
 */

using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SnapShotManager : MonoBehaviour
{
    // /Exports
    static int _screenShotCounter = 0;
    public bool _capture;
    Camera _graphCamera;
    string _directoryName;
    RenderTexture _tempRT;
    Text _messageText;
    float _messageTimeStamp;
    string exportBasePath;
    public JSONconfig _configuration; //configuration reference
    /// <summary>
    /// Grabs directory, finds first nonexistant directory
    /// </summary>
    void Start()
    {
        
        int directoryNumber = 0;

        exportBasePath = _configuration.loadedConfig.imageExportPath;


        while (Directory.Exists(exportBasePath + "/ScreenShots" + directoryNumber.ToString()))
            directoryNumber++;


        _directoryName = exportBasePath + "/ScreenShots" + directoryNumber.ToString();

        Directory.CreateDirectory(_directoryName);

        _graphCamera = GetComponent<Camera>();

        _messageText = GameObject.Find("ROOT/UI/CPANEL_LEFT/CPANEL_BOTTOM_L/SCREENSHOT_MESSAGE").GetComponent<Text>();
        _messageText.enabled = false;
    }

    /// <summary>
    /// Hides text message of screenshot saved after 2 seconds
    /// </summary>
    void Update()
    {
        if (Time.timeSinceLevelLoad - _messageTimeStamp > 2)
            _messageText.enabled = false;
    }

    /// <summary>
    /// Captures screenshot using render textures
    /// </summary>
    void LateUpdate()
    {
        if (_capture)
        {
            int sqr = 1024;
            _capture = false;
            // the 24 can be 0,16,24, formats like
            // RenderTextureFormat.Default, ARGB32 etc.
            _tempRT = new RenderTexture(1024, 1024, 24);
            RenderTexture target = _graphCamera.targetTexture;
            _graphCamera.targetTexture = _tempRT;
            _graphCamera.Render();
            RenderTexture.active = _tempRT;
            Texture2D virtualPhoto =
                new Texture2D(sqr, sqr, TextureFormat.RGB24, false);
            // false, meaning no need for mipmaps
            virtualPhoto.ReadPixels(new Rect(0, 0, sqr, sqr), 0, 0);
            RenderTexture.active = null; //can help avoid errors 
            _graphCamera.targetTexture = target;
            Destroy(_tempRT);
            byte[] bytes;
            bytes = virtualPhoto.EncodeToPNG();
            System.IO.File.WriteAllBytes(
               _directoryName + "/" + _screenShotCounter.ToString() + ".png", bytes);
            _messageText.enabled = true;
            _messageText.text = "Graph Saved to " + _directoryName + "/" + _screenShotCounter.ToString() + ".png";
            _messageTimeStamp = Time.timeSinceLevelLoad;
            _screenShotCounter++;
        }
    }

    public void CreateScreenShot()
    {
        _capture = true;
    }
}
