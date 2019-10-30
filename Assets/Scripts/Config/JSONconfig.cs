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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class JSONconfig : MonoBehaviour
{
    string jsonString;
    string filename = "/jsonFile.json";
    DefaultConfig config = new DefaultConfig();
    DefaultConfig defaultValues = new DefaultConfig();

    // validates property values
    public void Validation(DefaultConfig config)
    {
        if (config.minRadius < 1 || config.minRadius >= config.maxRadius)
        {
            config.minRadius = defaultValues.minRadius;
        }
        if (config.maxRadius < config.minRadius)
        {
            config.maxRadius = defaultValues.maxRadius;
        }
        if (config.minWindSpeed < 1 || config.minWindSpeed >= config.maxWindSpeed)
        {
            config.minWindSpeed = defaultValues.minWindSpeed;
        }
        if (config.maxWindSpeed < 2 || config.maxWindSpeed <= config.minWindSpeed)
        {
            config.maxWindSpeed = defaultValues.maxWindSpeed;
        }

    }
    void Awake()
    {
        string path = Application.dataPath + "/Scripts/Config" + filename;
        string root = Application.dataPath;
        if (File.Exists(path) == true)
        {
            // reads existing JSON file at path and checks for errors
            jsonString = File.ReadAllText(path);
            try
            {
                config = JsonUtility.FromJson<DefaultConfig>(jsonString);
                Validation(config);
                // check if directory exists and creates directory if it does not exist
                if (!Directory.Exists(root + config.csvExportPath))
                {
                    Directory.CreateDirectory(root + config.csvExportPath);
                }
                if (!Directory.Exists(root + config.csvExportPath))
                {
                    Directory.CreateDirectory(root + config.imageExportPath);
                }

            }       
            catch
            {
                // uses default values for JSON config when error is caught
                string newJson = defaultValues.SaveToString();
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.Write(newJson);
                    }
                }
            }
        } else
        {
            // creates JSON file if it does not exist at path
            string newJson = defaultValues.SaveToString();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(newJson);
                }
            }          
        }
        Debug.Log(config.minRadius);
        Debug.Log(config.maxRadius);
    }
}

[Serializable]
// class of properties with default values
public class DefaultConfig
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





