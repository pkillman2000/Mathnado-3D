using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathnadoController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    Color _mellowColor;
    [SerializeField]
    Color _angryColor;
    [SerializeField]
    float _transitionTime;

    Color _lerpedColor;
    Gradient _grad = new Gradient();
    ParticleSystem _ps;
    ParticleSystem.ColorOverLifetimeModule _col;

    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
        _col = _ps.colorOverLifetime;
        _lerpedColor = _mellowColor;

        _col.enabled = true;

        _grad.SetKeys(new GradientColorKey[] { new GradientColorKey(_lerpedColor, 0f), 
            new GradientColorKey(_lerpedColor, 0f) }, new GradientAlphaKey[] 
            { new GradientAlphaKey(1.0f, 0f), new GradientAlphaKey(1.0f, 0f) });

        _col.color = _grad;
    }


    void Update()
    {
        
    }

    private void MoveToPlayer(int playerNumber)
    {
        // Move left or right until trigger enter

        /*
         * this.transform.position = new Vector3(this.transform.position.x - (_moveSpeed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "House")
        {
            MoveToHome();
        }
    }

    private void MoveToHome()
    {

    }

    private void GetAngry()
    {
        /*
        *if(t <= 1)
        *{
        *_mathnadoLerpedColor = Color.Lerp(_mellowColor, _angryColor, Mathf.Lerp(0,1, t += Time.deltaTime/_duration));
        
         *GradientColorKey(_mathnadoLerpedColor, 0f), new GradientColorKey(_mathnadoLerpedColor, 0f)}, 
        *new GradientAlphaKey[]{new GradientAlphaKey(1.0f, 0f), new GradientAlphaKey(1.0f, 0f)});
        *_mathnadoCol.color = _grad;
        *}
        */
    }

    private void GetMellow()
    {
        /*
        *if(t <= 1)
        *{
        *_mathnadoLerpedColor = Color.Lerp(_angryColor, _mellowColor, Mathf.Lerp(0,1, t += Time.deltaTime/_duration));
        *GradientColorKey(_mathnadoLerpedColor, 0f), new GradientColorKey(_mathnadoLerpedColor, 0f)}, 
        *new GradientAlphaKey[]{new GradientAlphaKey(1.0f, 0f), new GradientAlphaKey(1.0f, 0f)});
        *_mathnadoCol.color = _grad;
        *}
        */
    }

}
