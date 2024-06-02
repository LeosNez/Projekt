using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text tutorialText;
    public GameObject canvas;

    private int currentStep = 0;

    void Start()
    {
        DisplayInstructions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentStep == 0)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentStep == 1)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && currentStep == 2)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && currentStep == 3)
        {
            currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.T) && currentStep == 4)
        {
            currentStep++;
            DisplayInstructions();
        }
    }

    void DisplayInstructions()
    {
        switch (currentStep)
        {
            case 0:
                tutorialText.text = "V�tej u tutorialu. Nap�ed zkus popojed dop�edu tak, �e zm��kne� �ipku dop�edu.";
                break;
            case 1:
                tutorialText.text = "Skv�le! Te� si zkus�me couv�n�. To ud�l� t�m, �e zm��kne� �ipku zp�t.";
                break;
            case 2:
                tutorialText.text = "Nyn� se rozje� dop�edu nebo dozadu a u toho zkus zato�it doleva tak, �e b�hem toho co je tv� auto v pohybu zm��kne� �ipku doleva.";
                break;
            case 3:
                tutorialText.text = "A nyn� zkus zato�it doprava";
                break;
            case 4:
                tutorialText.text = "Pro zrychlen� stiskn�te T";
                break;
            default:
                tutorialText.text = "Blahop�eji! �sp�n� si pro�el tutorialem :)";
                canvas.SetActive(true);
                break;
        }
    }
}