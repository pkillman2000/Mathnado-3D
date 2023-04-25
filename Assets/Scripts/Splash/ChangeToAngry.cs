using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToAngry : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _mathnadoParticle;
    [SerializeField]
    ParticleSystem _cloudSwirlParticle;
    [SerializeField]
    ParticleSystem _debrisParticle;
    [SerializeField]
    ParticleSystem _debrisCloudParticle;

    [SerializeField]
    Camera _camera;

    [SerializeField]
    Color _mathnadoMellowColor;
    [SerializeField]
    Color _mathnadoAngryColor;
    [SerializeField]
    Color _skyMellowColor;
    [SerializeField]
    Color _skyAngryColor;

    [SerializeField]
    float _duration;

    Color _mathnadoLerpedColor;
    Gradient _grad = new Gradient();
    ParticleSystem.ColorOverLifetimeModule _mathnadoCol;
    ParticleSystem.ColorOverLifetimeModule _cloudSwirlCol;
    ParticleSystem.ColorOverLifetimeModule _debrisCol;
    ParticleSystem.ColorOverLifetimeModule _debrisCloudCol;

    float t = 0;

    void Start()
    {
        _mathnadoCol = _mathnadoParticle.colorOverLifetime;
        _cloudSwirlCol = _cloudSwirlParticle.colorOverLifetime;
        _debrisCol = _debrisParticle.colorOverLifetime; 
        _debrisCloudCol = _debrisCloudParticle.colorOverLifetime;

        _mathnadoLerpedColor = _mathnadoMellowColor;

        _duration = FindObjectOfType<SplashSceneManager>().GetDurationBeforeChange();
    }


    void Update()
    {
        if (t <= 1)
        {
            // Change sky color
            _camera.backgroundColor = Color.Lerp(_skyMellowColor, _skyAngryColor, t += Time.deltaTime / _duration);

            // Change Mathnado color
           _mathnadoLerpedColor = Color.Lerp(_mathnadoMellowColor, _mathnadoAngryColor, Mathf.Lerp(0, 1, t += Time.deltaTime / _duration));

            _grad.SetKeys(new GradientColorKey[] { new GradientColorKey(_mathnadoLerpedColor, 0f),
            new GradientColorKey(_mathnadoLerpedColor, 0f) }, new GradientAlphaKey[]
             { new GradientAlphaKey(1.0f, 0f), new GradientAlphaKey(1.0f, 0f) });
            
            _mathnadoCol.color = _grad;
            _cloudSwirlCol.color = _grad;
            _debrisCol.color = _grad;
            _debrisCloudCol.color = _grad;
        }
    }

    private void AngryChange()
    {

    }

    private void FriendlyChange()
    {

    }
}
