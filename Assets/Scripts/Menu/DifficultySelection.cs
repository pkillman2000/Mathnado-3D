using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DifficultySelection : MonoBehaviour
{
    [SerializeField]
    private Button[] _difficultySelectButtons;
    [SerializeField]
    private Sprite[] _difficultyActiveSprites;
    [SerializeField]
    private Sprite[] _difficultyInactiveSprites;
    [SerializeField]
    private string[] _difficultyNames;
    [SerializeField]
    private GameSettings _gameSettings;

    [SerializeField]
    private PanelController _panelController;

    void Start()
    {
        SetButtonActive(0);
    }

    private void SetButtonsInactive() // Set all buttons to black background
    {
        for(int i = 0; i < _difficultySelectButtons.Length; i++)
        {
            _difficultySelectButtons[i].image.sprite = _difficultyInactiveSprites[i];
        }
    }

    public void SetButtonActive(int buttonIndex) // Set selected button to white background
    {
        SetButtonsInactive();
        _difficultySelectButtons[buttonIndex].image.sprite = _difficultyActiveSprites[buttonIndex];

        /*
         * 0 = Easy, 1 = Average, 2 = Hard, 3 = Insane, 4 = Custom
        */
        _gameSettings.SetDifficultyType(buttonIndex);

        switch(buttonIndex)
        {
            case 0: // Easy
                for(int i = 0; i < 2; i++)
                {
                    _gameSettings.SetNumberOfLives(i, 5);
                    _gameSettings.SetDuration(i, 3);
                    _gameSettings.SetTimer(i, 10);
                    _gameSettings.SetNumberOfQuestions(i, 10);
                    _gameSettings.SetAIIntelligence(i, 3);
                    _gameSettings.SetLowerLimit(i, 0);
                    _gameSettings.SetUpperLimit(i, 10);
                }
                
                break;

                case 1: // Average
                for (int i = 0; i < 2; i++)
                {
                    _gameSettings.SetNumberOfLives(i, 3);
                    _gameSettings.SetDuration(i, 5);
                    _gameSettings.SetTimer(i, 5);
                    _gameSettings.SetNumberOfQuestions(i, 30);
                    _gameSettings.SetAIIntelligence(i, 5);
                    _gameSettings.SetLowerLimit(i, 0);
                    _gameSettings.SetUpperLimit(i, 10);
                }

                break;

            case 2: // Hard
                for (int i = 0; i < 2; i++)
                {
                    _gameSettings.SetNumberOfLives(i, 2);
                    _gameSettings.SetDuration(i, 10);
                    _gameSettings.SetTimer(i, 3);
                    _gameSettings.SetNumberOfQuestions(i, 50);
                    _gameSettings.SetAIIntelligence(i, 8);
                    _gameSettings.SetLowerLimit(i, 0);
                    _gameSettings.SetUpperLimit(i, 50);
                }

                break;

            case 3: // Insane
                for (int i = 0; i < 2; i++)
                {
                    _gameSettings.SetNumberOfLives(i, 1);
                    _gameSettings.SetDuration(i, 30);
                    _gameSettings.SetTimer(i, 2);
                    _gameSettings.SetNumberOfQuestions(i, 100);
                    _gameSettings.SetAIIntelligence(i, 10);
                    _gameSettings.SetLowerLimit(i, 0);
                    _gameSettings.SetUpperLimit(i, 100);
                }

                break;

            case 4: // Custom

                _panelController.DisplayCustomSettings();

                break;
        }

    }
}
