using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuPanel;
    [SerializeField] 
    private GameObject _customSettingsPanel;
    [SerializeField]
    private GameObject _howToPlayPanel;
    [SerializeField]
    private GameObject _highScoresPanel;

    void Start()
    {
        HideAllPanels();
        _mainMenuPanel.SetActive(true);
    }

    private void HideAllPanels()
    {
        _mainMenuPanel.SetActive(false);
        _customSettingsPanel.SetActive(false);
        _howToPlayPanel.SetActive(false);
        _highScoresPanel.SetActive(false);
    }

    public void DisplayMainMenu()
    {
        HideAllPanels();
        _mainMenuPanel.SetActive(true);
    }

    public void DisplayCustomSettings()
    {
        HideAllPanels();
        _customSettingsPanel.SetActive(true);
    }

    public void DisplayHowToPlay()
    {
        HideAllPanels();
        _howToPlayPanel.SetActive(true);
    }

    public void DisplayHighScores() 
    {
        HideAllPanels();
        _highScoresPanel.SetActive(true);
    }
}
