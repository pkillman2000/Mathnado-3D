using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomDifficulty : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _errorMessage;

    [Header("Groups")]
    [SerializeField]
    private GameObject _numberOfLivesGroup;
    [SerializeField] 
    private GameObject _durationGroup;
    [SerializeField]
    private GameObject _numberOfQuestionsGroup;
    [SerializeField]
    private GameObject _timerGroup;
    [SerializeField]
    private GameObject _aiIntelligenceGroup;
    [SerializeField]
    private GameObject _lowerLimitGroup;
    [SerializeField]
    private GameObject _upperLimitGroup;

    [Header("Input Fields")]
    [SerializeField]
    private TMP_InputField[] _numberOfLivesInput;
    [SerializeField]
    private TMP_InputField[] _durationInput;
    [SerializeField]
    private TMP_InputField[] _numberOfQuestionsInput;
    [SerializeField]
    private TMP_InputField[] _timerInput;
    [SerializeField]
    private TMP_InputField[] _aiIntelligenceInput;
    [SerializeField]
    private TMP_InputField[] _lowerLimitInput;
    [SerializeField]
    private TMP_InputField[] _upperLimitInput;


    [SerializeField]
    private GameSettings _gameSettings;
    [SerializeField]
    private PanelController _panelController;

    private bool _errorMessageActive = false;

    private void OnEnable()
    {
        ShowAllControls();

        SetValuesToAllControls();

        ParseControlsBasedOnGameType();
    }

    private void ShowAllControls()
    {
        _numberOfLivesGroup.SetActive(true);
        _durationGroup.SetActive(true);
        _numberOfQuestionsGroup.SetActive(true);
        _timerGroup.SetActive(true);
        _aiIntelligenceGroup.SetActive(true);
        _aiIntelligenceInput[0].ActivateInputField();
        _aiIntelligenceInput[1].ActivateInputField();
        _lowerLimitGroup.SetActive(true);
        _upperLimitGroup.SetActive(true);
    }

    private void SetValuesToAllControls()
    {
        // Set values to all controls
        for (int i = 0; i < 2; i++)
        {
            _numberOfLivesInput[i].text = _gameSettings.GetNumberOfLives(i).ToString();
            _durationInput[i].text = _gameSettings.GetDuration(i).ToString();
            _numberOfQuestionsInput[i].text = _gameSettings.GetNumberOfQuestions(i).ToString();
            _timerInput[i].text = _gameSettings.GetTimer(i).ToString();
            _aiIntelligenceInput[i].text = _gameSettings.GetAIIntelligence(i).ToString();
            _lowerLimitInput[i].text = _gameSettings.GetLowerLimit(i).ToString();
            _upperLimitInput[i].text = _gameSettings.GetUpperLimit(i).ToString();
        }
    }

    private void ParseControlsBasedOnGameType()
    {
        // Parse controls based on game type
        switch (_gameSettings.GetGameType())
        {
            case 0: // Duration
                _numberOfQuestionsGroup.SetActive(false);
                _timerGroup.SetActive(false);
                break;

            case 1: // Questions
                _durationGroup.SetActive(false);
                _timerGroup.SetActive(false);
                break;

            case 2: // Duration-Timer
                _numberOfQuestionsGroup.SetActive(false);
                break;

            case 3: // Question-Timer
                _durationGroup.SetActive(false);
                break;

            case 4: // Speed
                _numberOfQuestionsGroup.SetActive(false);
                _timerGroup.SetActive(false);
                break;

            case 5: // Death
                _durationGroup.SetActive(false);
                _numberOfQuestionsGroup.SetActive(false);
                _timerGroup.SetActive(false);
                break;
        }

        // Hide player AI fields or AI group based upon if any players are AIs
        if (_gameSettings.GetPlayerIsAI(0) || _gameSettings.GetPlayerIsAI(1))
        {
            for (int i = 0; i < 2; i++)
            {
                if (!_gameSettings.GetPlayerIsAI(i))
                {
                    _aiIntelligenceInput[i].DeactivateInputField();
                }
            }
        }
        else
        {
            _aiIntelligenceGroup.SetActive(false);
        }
    }

    public void CheckForInputErrors()
    {
        string errormessage = "";
        int value;
        int lowerLimit;
        int upperLimit;

        _errorMessageActive = false;

        for(int i = 0; i < 2; i++)
        {            
            // Number of Lives
            value = int.Parse(_numberOfLivesInput[i].text);
            if (value > 0 && value < 6)
            {
                _gameSettings.SetNumberOfLives(i, value);
            }
            else
            {
                _errorMessageActive = true;
                errormessage += "Number of lives for Player " + i.ToString() + " must be between 1 - 5.  ";
            }            

            // Duration
            value = int.Parse(_durationInput[i].text);

            if (value > 0 && value < 31)
            {
                _gameSettings.SetDuration(i, value);
            }
            else
            {
                _errorMessageActive = true;
                errormessage += "Duration for Player " + i.ToString() + " must be between 1 - 30.  ";
            }
            

            // Number of Questions
            value = int.Parse(_numberOfQuestionsInput[i].text);
            if (value > 0 && value < 101)
            {
                _gameSettings.SetNumberOfQuestions(i, value);
            }
            else
            {
                _errorMessageActive = true;
                errormessage += "Number of questions for Player " + i.ToString() + " must be between 1 - 100.  ";
            }

            // Timer
            value = int.Parse(_timerInput[i].text);

            if (value > 0 && value < 21)
            {
                _gameSettings.SetTimer(i, value);
            }
            else
            {
                _errorMessageActive = true;
                errormessage += "Timer for Player " + i.ToString() + " must be between 1 - 20.  ";
            }

            // AI Intelligence
            value = int.Parse(_aiIntelligenceInput[i].text);

            if (value > 0 && value < 11)
            {
                _gameSettings.SetAIIntelligence(i, value);
            }
            else
            {
                _errorMessageActive = true;
                errormessage += "AI intelligence for Player " + i.ToString() + " must be between 1 - 10.  ";
            }

            // Lower Limit
            lowerLimit = int.Parse(_lowerLimitInput[i].text);

            if (lowerLimit > -1 && lowerLimit < 100)
            {
                _gameSettings.SetLowerLimit(i, lowerLimit);
            }
            else
            {
                _errorMessageActive = true;
                errormessage += "Lower limit for Player " + i.ToString() + " must be between 1 - 99.  ";
            }

            // Upper Limit
            upperLimit = int.Parse(_upperLimitInput[i].text);

            if (upperLimit > 1 && upperLimit < 101)
            {
                _gameSettings.SetUpperLimit(i, upperLimit);
            }
            else
            {
                _errorMessageActive = true;
                errormessage += "Upper limit for Player " + i.ToString() + " must be between 2 - 100.  ";
            }

            // Check Lower Limit vs Upper Limit
            if(lowerLimit >= upperLimit)
            {
                _errorMessageActive = true;
                errormessage += "Lower limit for Player " + i.ToString() + " must be less than upper limit.  ";
            }
            else
            {
                _gameSettings.SetLowerLimit(i, lowerLimit);
                _gameSettings.SetUpperLimit(i, upperLimit);
            }
        }

        if(!_errorMessageActive)
        {
            _panelController.DisplayMainMenu();
        }
        else
        {
            _errorMessage.text = errormessage;
        }
    }
}
