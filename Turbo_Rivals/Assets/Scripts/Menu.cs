using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument _uiDocument;

    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();

        // Z�sk�n� root vizu�ln�ho stromu z UI dokumentu
        var rootVisualElement = _uiDocument.rootVisualElement;

        // Najd�te tla��tko podle jeho jm�na (podle jm�na z UXML)
        Button tutButton = rootVisualElement.Q<Button>("Tutorial");

        // P�i�a�te metodu, kter� se spust� p�i kliknut�
        tutButton.clicked += TutorialClick;

        Button prvniButton = rootVisualElement.Q<Button>("Lvl1");

        prvniButton.clicked += PrvniClick;

        Button druhyButton = rootVisualElement.Q<Button>("Lvl2");

        druhyButton.clicked += DruhyClick;

        Button tretiButton = rootVisualElement.Q<Button>("Lvl3");

        tretiButton.clicked += TretiClick;

        Button ctvrtyButton = rootVisualElement.Q<Button>("Lvl4");

        ctvrtyButton.clicked += CtvrtyClick;

        Button ldbrButton = rootVisualElement.Q<Button>("Ldbr");

        ldbrButton.clicked += LdbrClick;

        Button extButton = rootVisualElement.Q<Button>("Ext");

        extButton.clicked += ExtClick;
    }

    // Metoda pro zm�nu sc�ny
    void TutorialClick()
    {
        // Zm�na sc�ny na jinou
        SceneManager.LoadScene("Tutorial");
    }

    void PrvniClick()
    {
        SceneManager.LoadScene("Level1");
    }

    void DruhyClick()
    {
        SceneManager.LoadScene("Level2");
    }

    void TretiClick()
    {
        SceneManager.LoadScene("Level3");
    }

    void CtvrtyClick()
    {
        SceneManager.LoadScene("Level4");
    }

    void LdbrClick()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    void ExtClick()
    {
        SceneManager.LoadScene("StartUpMenu");
    }
}