using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public Text Cas;

    public void SaveToFile()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "Leaderboard.txt");

        // Otev�en� souboru pro z�pis
        StreamWriter writer = new StreamWriter(filePath, true);

        // Z�pis dat do souboru
        writer.WriteLine(Cas.text);

        // Uzav�en� souboru
        writer.Close();

        UnityEngine.Debug.Log("Data byla ulo�ena do souboru: " + filePath);
    }
}
