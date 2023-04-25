using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneManager : MonoBehaviour
{
    [SerializeField]
    string _sceneToLoad;
    [SerializeField]
    float _durationBeforeChange;
    [SerializeField]
    float _durationOfChange;

    private ScreenFader _screenFader;

    void Start()
    {
        /*
        _screenFader = GameObject.Find("Screen Fader").GetComponent<ScreenFader>();
        if ( _screenFader == null )
        {
            Debug.LogWarning("Screen Fader is Null");
        }

        _screenFader.FadeFromBlack();

        StartCoroutine(FadeToBlack());
        */
    }

    public float GetDurationBeforeChange()
    {
        return _durationBeforeChange;
    }
    IEnumerator FadeToBlack()
    {
        yield return new WaitForSeconds(_durationBeforeChange);
        _screenFader.FadeToBlack();
        StartCoroutine(ChangeToNextScene());

    }

    IEnumerator ChangeToNextScene()
    {
        yield return new WaitForSeconds(_durationOfChange);
        //SceneManager.LoadScene(_sceneToLoad);
    }
}
