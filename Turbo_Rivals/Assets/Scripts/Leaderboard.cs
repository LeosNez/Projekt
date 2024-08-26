using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text NameTextField;
    public Text TimeTextField;
    public int LvlNum;

    public void Lead()
    {
        // Inicializace seznamu pro ukl�d�n� jmen hr��� a jejich �as�
        List<Tuple<string, TimeSpan>> playerTimes = new List<Tuple<string, TimeSpan>>();

        // Cesta k textov�mu souboru Leaderboardu ur�en�mu pro konkr�tn� �rove� (lvlNum)
        string filePath = Path.Combine(Application.persistentDataPath, "Leaderboard_" + LvlNum + ".txt");

        // Na�ten� v�ech ��dk� textov�ho souboru do pole �et�zc�
        string[] lines = File.ReadAllLines(filePath);

        // Regul�rn� v�raz pro extrakci jmen a �as� hr��� ve form�tu "jm�no 00:00:00"
        Regex entryRegex = new Regex(@"(\w+)\s+(\d{2}:\d{2}:\d{2})");

        // Projdi ka�d� ��dek textov�ho souboru
        foreach (string line in lines)
        {
            // Pokud ��dek odpov�d� form�tu "jm�no 00:00:00"
            Match match = entryRegex.Match(line);
            if (match.Success)
            {
                // Extrahuj jm�no hr��e a jeho �as
                string playerName = match.Groups[1].Value;
                string timeString = match.Groups[2].Value;

                // Rozd�len� �asov�ho �et�zce na minuty, sekundy a setiny sekundy
                string[] timeParts = timeString.Split(':');
                if (timeParts.Length == 3 &&
                    int.TryParse(timeParts[0], out int minutes) &&
                    int.TryParse(timeParts[1], out int seconds) &&
                    int.TryParse(timeParts[2], out int miliseconds))
                {
                    // Vytvo�en� TimeSpan objektu pro �as hr��e
                    TimeSpan timeSpan = new TimeSpan(0, 0, minutes, seconds, miliseconds);
                    // P�id�n� jm�na hr��e a jeho �asu do seznamu
                    playerTimes.Add(new Tuple<string, TimeSpan>(playerName, timeSpan));
                }
            }
        }

        // Se�azen� hr��� podle �asu
        playerTimes = playerTimes.OrderBy(pt => pt.Item2).Take(5).ToList();

        // Vytvo�en� seznamu �et�zc� pro zobrazen� v textov�ch pol�ch
        List<string> nameEntries = new List<string>();
        List<string> timeEntries = new List<string>();

        foreach (var playerTime in playerTimes)
        {
            // P�id�n� jm�na a �asu hr��e do p��slu�n�ch seznam�
            nameEntries.Add(playerTime.Item1);
            timeEntries.Add($"{playerTime.Item2.Minutes:D2}:{playerTime.Item2.Seconds:D2}:{playerTime.Item2.Milliseconds:D2}");
        }

        // P�eveden� seznam� �et�zc� na jedin� �et�zec se znaky nov�ho ��dku
        string nameText = string.Join("\n", nameEntries);
        string timeText = string.Join("\n", timeEntries);

        // Zobrazen� leaderboardu v textov�ch pol�ch
        NameTextField.text = nameText;
        TimeTextField.text = timeText;
    }
}