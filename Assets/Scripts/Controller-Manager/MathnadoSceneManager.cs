using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This script switches between scenes
 * and includes the Screen Fader.
 * The Screen Fader object has a child image that is set to black.
 * The image is scaled to whatever size you need it to be.
 * To use the Screen Fader, place it in your canvas at the 
 * very bottom of the hierarchy.
*/

public class MathnadoSceneManager : MonoBehaviour
{
    // Attach a black image here.
    // Make sure the image is scaled appropriately.
    [SerializeField]
    private Image _fadeImage;

    // The larger the number, the faster the fade speed  (1/_fadeSpeed)
    // .5 = 2 seconds
    // 1 = 1 second
    // 2 = .5 seconds
    [SerializeField]
    private float _fadeSpeed;

    // It is assumed that a new scene needs to be faded in to.
    private void Start()
    {
        FadeFromBlack();
    }

    // This is used to test fade speed.  It can be deleted
    // or remarked out when no longer needed.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            FadeToBlack();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            FadeFromBlack();
        }
    }

    // Scene Changing Methods
    public void ChangeScene(string scene)
    {
        StartCoroutine(LoadSceneRoutine(scene));
    }

    private IEnumerator LoadSceneRoutine(string scene)
    {
        FadeToBlack();
        yield return new WaitForSeconds(1 / _fadeSpeed);
        SceneManager.LoadScene(scene);
        FadeFromBlack();
    }

    // Screen Fader Methods
    public void FadeToBlack()
    {
        StartCoroutine(FadeToBlackRoutine());
    }

    public void FadeFromBlack()
    {
        StartCoroutine(FadeFromBlackRoutine());
    }

    private IEnumerator FadeToBlackRoutine()
    {
        Color objectColor = _fadeImage.color;
        float fadeAmount;

        _fadeImage.gameObject.SetActive(true);

        while (_fadeImage.color.a < 1)
        {
            fadeAmount = objectColor.a + (_fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);

            if (objectColor.a > 1)
            {
                objectColor.a = 1;
            }
            _fadeImage.color = objectColor;
            yield return null;
        }
    }

    private IEnumerator FadeFromBlackRoutine()
    {
        Color objectColor = _fadeImage.color;
        float fadeAmount;

        while (_fadeImage.color.a > 0)
        {
            fadeAmount = objectColor.a - (_fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);

            if (objectColor.a < 0)
            {
                objectColor.a = 0;
            }
            _fadeImage.color = objectColor;
            yield return null;
        }

        _fadeImage.gameObject.SetActive(false);
    }


}
