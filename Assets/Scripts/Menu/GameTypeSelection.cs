using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTypeSelection : MonoBehaviour
{
    [SerializeField]
    private Button[] _gameTypeSelectButtons;
    [SerializeField]
    private Sprite[] _gameTypeActiveSprites;
    [SerializeField]
    private Sprite[] _gameTypeInactiveSprites;
    [SerializeField]
    private string[] _gameTypeNames;
    [SerializeField]
    private GameSettings _gameSettings;

    void Start()
    {
        SetButtonActive(0);
    }

    private void SetButtonsInactive()
    {
        for(int i = 0; i < _gameTypeSelectButtons.Length; i++)
        {
            _gameTypeSelectButtons[i].image.sprite = _gameTypeInactiveSprites[i];
        }
    }

    public void SetButtonActive(int buttonIndex)
    {
        SetButtonsInactive();
        _gameTypeSelectButtons[buttonIndex].image.sprite = _gameTypeActiveSprites[buttonIndex];

       /*
        * 0 = Duration, 1 = Question, 2 = Duration-Timer, 3 = Question-Timer, 4 = Speed, 5 = Death
       */

        _gameSettings.SetGameType(buttonIndex);
    }
}
