using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathTypeSelection : MonoBehaviour
{

    [SerializeField]
    private Button[] _mathSelectButtons;
    [SerializeField]
    private Sprite[] _mathActiveSprites;
    [SerializeField]
    private Sprite[] _mathInactiveSprites;
    [SerializeField]
    private string[] _mathTypeNames;
    [SerializeField]
    private GameSettings _gameSettings;

    void Start()
    {
        SetButtonActive(0);
    }

    private void SetButtonsInactive()
    {
        for(int i = 0; i < _mathSelectButtons.Length; i++)
        {
            _mathSelectButtons[i].image.sprite = _mathInactiveSprites[i];
        }
    }

    public void SetButtonActive(int buttonIndex)
    {
        SetButtonsInactive();
        _mathSelectButtons[buttonIndex].image.sprite = _mathActiveSprites[buttonIndex];

       _gameSettings.SetMathType(buttonIndex);
    }
}
