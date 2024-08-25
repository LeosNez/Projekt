using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public AudioSource RadioSource;
    public AudioClip[] ListSongu;

    public Toggle myToggle;

    void Start()
    {
        // Na�ten� stavu Toggle p�i startu hry
        if (PlayerPrefs.HasKey("ToggleState"))
        {
            myToggle.isOn = PlayerPrefs.GetInt("ToggleState") == 1;
        }
        else
        {
            myToggle.isOn = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!RadioSource.isPlaying)
        {
            AudioClip randomClip = ListSongu[UnityEngine.Random.Range(0, ListSongu.Length)];

            RadioSource.PlayOneShot(randomClip);
        }
    }

    void OnDisable()
    {
        // Ulo�en� stavu Toggle p�i deaktivaci objektu (nap�. p�i zm�n� sc�ny)
        SaveToggleState();
    }

    void SaveToggleState()
    {
        // Ulo�en� stavu Toggle (1 pokud je zapnut�, 0 pokud je vypnut�)
        PlayerPrefs.SetInt("ToggleState", myToggle.isOn ? 1 : 0);
        PlayerPrefs.Save(); // Voliteln� m��ete zavolat Save() pro zaji�t�n� okam�it�ho ulo�en�
    }
}
