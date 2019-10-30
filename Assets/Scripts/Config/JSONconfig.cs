/* JSONconfig.cs
 * 10.28.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Script checks the path for an existing JSON config file and
 * creates a config object. The properties of the JSON will also be validated.
 * Script will also create a new directory if desired export path does not
 * exist. If no JSON config file exists, a new config file with default values
 * will be created. A default config object will be created under those
 * conditions. 
 * 
 */

using System;
using System.IO;
using UnityEngine;

[Serializable]
public class JSONconfig : MonoBehaviour
{
    string jsonString;
    string filename = "/config.json";
    public Configuration loadedConfig = new Configuration();
    public Configuration defaultConfig = new Configuration();

    // validates property values
    public void Validation(Configuration config)
    {
        if (config.minRadius < 1 || config.minRadius >= config.maxRadius)
        {
            config.minRadius = defaultConfig.minRadius;
        }
        if (config.maxRadius < config.minRadius)
        {
            config.maxRadius = defaultConfig.maxRadius;
        }
        if (config.minWindSpeed < 1 || config.minWindSpeed >= config.maxWindSpeed)
        {
            config.minWindSpeed = defaultConfig.minWindSpeed;
        }
        if (config.maxWindSpeed < 2 || config.maxWindSpeed <= config.minWindSpeed)
        {
            config.maxWindSpeed = defaultConfig.maxWindSpeed;
        }

    }
    void Awake()
    {
        string cfgpath = "/Config";
        string path = Application.dataPath + cfgpath + filename;
        string root = Application.dataPath;

        try
        {

            if (!Directory.Exists(root + cfgpath))
            {
                Directory.CreateDirectory(root + cfgpath);
            }

            if (File.Exists(path) == true)
            {
                // reads existing JSON file at path and checks for errors
                jsonString = File.ReadAllText(path);
                try
                {
                    loadedConfig = JsonUtility.FromJson<Configuration>(jsonString);
                    Validation(loadedConfig);
                    // check if directory exists and creates directory if it does not exist
                    if (!Directory.Exists(root + loadedConfig.csvExportPath))
                    {
                        Directory.CreateDirectory(root + loadedConfig.csvExportPath);
                    }
                    if (!Directory.Exists(root + loadedConfig.csvExportPath))
                    {
                        Directory.CreateDirectory(root + loadedConfig.imageExportPath);
                    }
                }
                catch
                {
                    // uses default values for JSON config when error is caught
                    string newJson = defaultConfig.SaveToString();
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            writer.Write(newJson);
                        }
                    }
                }
            }
            else
            {
                // creates JSON file if it does not exist at path
                string newJson = defaultConfig.SaveToString();
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.Write(newJson);
                    }
                }
            }
            Debug.Log(loadedConfig.minRadius);
            Debug.Log(loadedConfig.maxRadius);
        }
        catch (Exception e)
        {
            loadedConfig = defaultConfig;
        }
    }
}

[Serializable]
// class of properties with default values
public class Configuration
{
    public bool colorWheel = true;
    public bool radiusSlider = true;
    public bool windSlider = true;
    public bool inflateDeflateButton = true;
    public bool recordButton = true;
    public bool graph = true;
    public bool dataBox = true;
    public string csvExportPath = "/Exports";
    public string imageExportPath = "/Exports";
    public int minRadius = 1;
    public int maxRadius = 10;
    public int minWindSpeed = 1;
    public int maxWindSpeed = 5;

    // puts properties and values into a string of JSON format
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}





