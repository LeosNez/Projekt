using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Odpocitavani : MonoBehaviour
{
    public Canvas countdownCanvas;
    public Canvas guiCanvas;
    public Text countdownText;

    public int countdown = 3;

    public AudioSource readySet;
    public AudioSource go;

    void Start()
    {
        // Spu�t�n� coroutine pro odpo��t�v�n�
        StartCoroutine(CountdownCoroutine()); //Korutina v Unity je speci�ln� typ metody, kter� m��e b�t asynchronn� spu�t�na a prov�d�na po dobu n�kolika sn�mk� hry
    }

    private IEnumerator CountdownCoroutine() //rozhran� v jazyce C#, kter� umo��uje implementovat iterativn� operace
    {
        // Zastaven� hry
        Time.timeScale = 0f;

        while (countdown > 0)
        {
            readySet.Play();
            countdownText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1); // Toto kl��ov� slovo se pou��v� k vr�cen� hodnoty z korutiny a do�asn�mu pozastaven� jej�ho b�hu
            countdown--;
        }

        countdownText.text = "GO!";
        go.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);

        // Deaktivace Canvasu po odpo��t�v�n�
        countdownCanvas.gameObject.SetActive(false);

        guiCanvas.gameObject.SetActive(true);

        // Obnoven� norm�ln� rychlosti hry
        Time.timeScale = 1f;
    }
}