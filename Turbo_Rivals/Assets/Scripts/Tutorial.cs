using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text TutorialText;
    public GameObject Canvas;

    private int _currentStep = 0;

    void Start()
    {
        DisplayInstructions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _currentStep == 0)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && _currentStep == 1)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && _currentStep == 2)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _currentStep == 3)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.T) && _currentStep == 4)
        {
            _currentStep++;
            DisplayInstructions();
        }
        else if (Input.GetKey(KeyCode.S) && _currentStep == 5)
        {
            _currentStep++;
            DisplayInstructions();
        }
    }

    void DisplayInstructions()
    {
        switch (_currentStep)
        {
            case 0:
                TutorialText.text = "V�tej u tutorialu. Nap�ed zkus popojed dop�edu tak, �e zm��kne� �ipku dop�edu.";
                break;
            case 1:
                TutorialText.text = "Skv�le! Te� si zkus�me couv�n�. To ud�l� t�m, �e zm��kne� �ipku zp�t.";
                break;
            case 2:
                TutorialText.text = "Nyn� se rozje� dop�edu nebo dozadu a u toho zkus zato�it doleva tak, �e b�hem toho co je tv� auto v pohybu zm��kne� �ipku doleva.";
                break;
            case 3:
                TutorialText.text = "A nyn� zkus zato�it doprava";
                break;
            case 4:
                TutorialText.text = "Pro zrychlen� stiskn�te T";
                break;
            case 5:
                TutorialText.text = "Te� zkus smyk pomoc� S";
                break;
            default:
                TutorialText.text = "Blahop�eji! �sp�n� si pro�el tutorialem :)";
                Canvas.SetActive(true);
                break;
        }
    }
}