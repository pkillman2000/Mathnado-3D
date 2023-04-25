using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFader : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _titleBlockGameObject;
 
    private float _duration;
    private Color[] _titleBlockColor;
    private float _fadeSpeed;
    private float _titleBlockAlpha = 0;

    void Start()
    {
        Color tmpColor;

        _duration = FindObjectOfType<SplashSceneManager>().GetDurationBeforeChange();

        // Populate sprite array
        _titleBlockColor = new Color[_titleBlockGameObject.Length];

        for(int i = 0; i < _titleBlockGameObject.Length; i++)
        {
            _titleBlockColor[i] = _titleBlockGameObject[i].GetComponent<SpriteRenderer>().color;
            tmpColor = _titleBlockColor[i];
            _titleBlockColor[i] = new Color(tmpColor.r, tmpColor.g, tmpColor.b, _titleBlockAlpha);
        }
        
        // Calculate fade speed
        _fadeSpeed = 1/_duration;
    }


    void Update()
    {
        Color tmpColor;
        
        _titleBlockAlpha += _fadeSpeed * Time.deltaTime;

        for (int i = 0; i < _titleBlockColor.Length; i++)
        {            
            tmpColor = _titleBlockColor[i];
            
            if(_titleBlockAlpha > 1)
            {
                _titleBlockAlpha = 1;
            }

            _titleBlockGameObject[i].GetComponent<SpriteRenderer>().color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, _titleBlockAlpha);
        }
    }
}
