using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _playerLabel;
    [SerializeField]
    private string _characterName;
    [SerializeField]
    private TMP_InputField _characterNameInput;
    [SerializeField]
    private Transform _characterHolder;
    [SerializeField]
    private Button _AISelectedButton;
    [SerializeField]
    private Sprite _AI_ActiveSprite;
    [SerializeField]
    private Sprite _AI_InactiveSprite;
    [SerializeField]
    private int _playerNumber;

    [SerializeField]
    private GameObject[] _characters;
    [SerializeField]
    private string[] _AIFirstNames;
    [SerializeField]
    private string[] _firstNames;
    [SerializeField]
    private string[] _lastNamesOne;
    [SerializeField]
    private string[] _lastNamesTwo;
    [SerializeField]
    private bool _characterIsAI = false;
    [SerializeField]
    private GameSettings _gameSettings;

    private GameObject _currentCharacter;
    private int _currentCharacterID = 0;

    void Start()
    {
        SetPlayerLabel();
        _currentCharacterID = _playerNumber;
        DisplayCharacter(_currentCharacterID);
        GeneratePlayerName();
    }

    private void DisplayCharacter(int characterID)
    {
        Vector3 characterLocation = new Vector3(_characterHolder.position.x, _characterHolder.position.y, _characterHolder.position.z);
        // Rotates character to face front while instantiating
        _currentCharacter = Instantiate(_characters[characterID], characterLocation, Quaternion.Inverse(_characters[characterID].transform.rotation));
        _currentCharacter.transform.parent = _characterHolder.transform;
        _gameSettings.SetCurrentAvatar(_playerNumber, characterID);

        //GameObject childObject = Instantiate(YourObject) as GameObject;
        //childObject.transform.parent = parentObject.transform
    }

        private void DestroyCurrentCharacter()
    {
        Destroy(_currentCharacter);
    }

    public void NextCharacter()
    {
        DestroyCurrentCharacter();
        if(_currentCharacterID < _characters.Length - 1)
        {
            _currentCharacterID++;
        }
        else
        {
            _currentCharacterID = 0;
        }
        
        DisplayCharacter(_currentCharacterID);
    }

    public void PreviousCharacter()
    {
        DestroyCurrentCharacter();
        if (_currentCharacterID > 0)
        {
            _currentCharacterID--;
        }
        else
        {
            _currentCharacterID = _characters.Length - 1;
        }
        
        DisplayCharacter(_currentCharacterID);
    }

    private void SetPlayerLabel()
    {
        if(_playerNumber == 0)
        {
            _playerLabel.text = "Player One";
        }
        else
        {
            _playerLabel.text = "Player Two";
        }
    }

    public void SetCharacterAI()
    {
        _characterIsAI = !_characterIsAI;
        
        // 0 = Human, 1 = AI
        if(_characterIsAI)
        {
            _AISelectedButton.image.sprite = _AI_ActiveSprite;
            _gameSettings.SetPlayerIsAI(_playerNumber, true);
        }
        else // Character is human
        {
            _AISelectedButton.image.sprite = _AI_InactiveSprite;
            _gameSettings.SetPlayerIsAI(_playerNumber, false);
        }

        GeneratePlayerName();
    }

    public void GeneratePlayerName()
    {
        int index;
        string firstName;
        string lastNameBegin;
        string lastNameEnd;

        // Clear input field
        _characterNameInput.text = "";

        // Pick first name based on human/AI
        if (_characterIsAI)
        {
            index = Random.Range(0, _AIFirstNames.Length);
            firstName = _AIFirstNames[index];
        }
        else
        {
            index = Random.Range(0, _firstNames.Length);
            firstName = _firstNames[index];
        }

        // Pick last name
        index = Random.Range(0, _lastNamesOne.Length);
        lastNameBegin = _lastNamesOne[index];

        index = Random.Range(0, _lastNamesTwo.Length);
        lastNameEnd = _lastNamesTwo[index];

        // Join names together into string
        // Update Character Name input field
        _characterName = (firstName + " " + lastNameBegin + lastNameEnd);
        _characterNameInput.text = _characterName;

        _gameSettings.SetPlayerName(_playerNumber, _characterName);
    }

    public void SetUserEnteredName()
    {
        _characterName = _characterNameInput.text;
        _gameSettings.SetPlayerName(_playerNumber, _characterName);
    }
}
