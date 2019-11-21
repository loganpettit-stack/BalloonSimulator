/* CSVexport.cs
 * 11.30.2019
 * Balloon Physics Simulator
 * Author: Team NoName
 * Description: Exports radius,surface area, volume, lift force,
 * mass, wind speed and weight to CSV file
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;



public class CSVexport : MonoBehaviour
{

    public dataCollect collect;
    private string dirname;
    public JSONconfig _configuration;
    
    private void Start()
    {

        dirname = _configuration.loadedConfig.csvExportPath;

        /*Initial creation of CSV directory*/
        if(!Directory.Exists(dirname))
        {
            Directory.CreateDirectory(dirname);
        }

        
        Save();
    }
    
    /*Record balloon info and write to csv file*/
    public void Save()
    {
       if (Directory.Exists(dirname))
       {
            string placeHolder = DateTime.UtcNow.ToString("dd MMMM, yyyy");
            string filePath = dirname + "/" + placeHolder + ".csv";
            StreamWriter outStream = System.IO.File.CreateText(filePath);
            string test = collect.getCSVFormat();
            outStream.WriteLine(test);
            outStream.Flush();
            outStream.Close();
            Debug.Log("it worked");
       }
    }
    
        
}
