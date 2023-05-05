using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField]
    private bool[] _playerIsAI = new bool[2]; //  False = Human, True = AI
    [SerializeField] 
    private int[] _currentAvatar = new int[2]; // Index of avatar
    [SerializeField] 
    private string[] _playerName = new string[2]; // Player name

    [Header("Game Type")]
    [SerializeField]
    private int _gameTypeSelected;

    [Header("Math Type")]
    [SerializeField]
    private int _mathTypeSelected;

    [Header("Difficulty")]
    [SerializeField]
    private int _difficultySelected;
    [SerializeField]
    private int[] _numberOfLives = new int[2];
    [SerializeField]
    private int[] _duration = new int[2];
    [SerializeField]
    private int[] _numberOfQuestions = new int[2];
    [SerializeField]
    private int[] _timer = new int[2];
    [SerializeField]
    private int[] _aiIntelligence = new int[2];
    [SerializeField]
    private int[] _lowerLimit = new int[2];
    [SerializeField]
    private int[] _upperLimit = new int[2];

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    /*
     * Player Settings
    */
    public void SetPlayerIsAI(int player, bool type)
    {
        _playerIsAI[player] = type;
    }

    public bool GetPlayerIsAI(int player)
    {
        return _playerIsAI[player];
    }

    public void SetCurrentAvatar(int player, int index)
    {
        _currentAvatar[player] = index;
    }

    public int GetCurrentAvatar(int player)
    {
        return _currentAvatar[player];
    }

    public void SetPlayerName(int player, string name)
    {
        _playerName[player] = name;
    }

    public string GetPlayerName(int player)
    {
        return _playerName[player];
    }

    /*
     * Game Type
     * 0 = Duration, 1 = Question, 2 = Duration-Timer, 3 = Question-Timer, 4 = Speed, 5 = Death
    */

    public void SetGameType(int type)
    {
        _gameTypeSelected = type;
    }

    public int GetGameType()
    {
        return _gameTypeSelected;
    }

    /*
     * Math Type
    */

    public void SetMathType(int type)
    {
        _mathTypeSelected = type;
    }

    public int GetMathType()
    {
        return _mathTypeSelected;
    }

    /*
     * Difficulty Type
     * 0 = Easy, 1 = Average, 2 = Hard, 3 = Insane, 4 = Custom
    */

    public void SetDifficultyType(int type)
    {
        _difficultySelected = type;
    }

    public int GetDifficulyType()
    {
        return _difficultySelected;
    }

    /*
     * Difficulty Settings
    */

    public void SetNumberOfLives(int player, int value)
    {
        _numberOfLives[player] = value;
    }

    public int GetNumberOfLives(int player)
    {
        return _numberOfLives[player];
    }

    public void SetDuration(int player, int value)
    {
        _duration[player] = value;
    }

    public int GetDuration(int player)
    {
        return _duration[player];
    }

    public void SetNumberOfQuestions(int player, int value)
    {
        _numberOfQuestions[player] = value;
    }

    public int GetNumberOfQuestions(int player)
    {
        return _numberOfQuestions[player];
    }

    public void SetTimer(int player, int value)
    {
        _timer[player] = value;
    }

    public int GetTimer(int player)
    {
        return _timer[player];
    }

    public void SetAIIntelligence(int player, int value)
    {
        _aiIntelligence[player] = value;
    }

    public int GetAIIntelligence(int player)
    {
        return _aiIntelligence[player];
    }

    public void SetLowerLimit(int player, int value)
    {
        _lowerLimit[player] = value;
    }

    public int GetLowerLimit(int player)
    {
        return _lowerLimit[player];
    }

    public void SetUpperLimit(int player, int value)
    {
        _upperLimit[player] = value;
    }

    public int GetUpperLimit(int player)
    {
        return _upperLimit[player];
    }
}
