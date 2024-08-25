using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Odpocitavani : MonoBehaviour
{
    public Canvas CountdownCanvas;
    public Canvas GuiCanvas;
    public Text CountdownText;

    public int Countdown = 3;

    public AudioSource ReadySet;
    public AudioSource Go;

    void Start()
    {
        // Spu�t�n� coroutine pro odpo��t�v�n�
        StartCoroutine(CountdownCoroutine()); //Korutina v Unity je speci�ln� typ metody, kter� m��e b�t asynchronn� spu�t�na a prov�d�na po dobu n�kolika sn�mk� hry
    }

    private IEnumerator CountdownCoroutine() //rozhran� v jazyce C#, kter� umo��uje implementovat iterativn� operace
    {
        // Zastaven� hry
        Time.timeScale = 0f;

        while (Countdown > 0)
        {
            ReadySet.Play();
            CountdownText.text = Countdown.ToString();
            yield return new WaitForSecondsRealtime(1); // Toto kl��ov� slovo se pou��v� k vr�cen� hodnoty z korutiny a do�asn�mu pozastaven� jej�ho b�hu
            Countdown--;
        }

        CountdownText.text = "GO!";
        Go.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1);

        // Deaktivace Canvasu po odpo��t�v�n�
        CountdownCanvas.gameObject.SetActive(false);

        GuiCanvas.gameObject.SetActive(true);

        // Obnoven� norm�ln� rychlosti hry
        Time.timeScale = 1f;
    }
}