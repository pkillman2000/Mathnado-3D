using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script controls how the characters behave.
 * It can rotate the characters for the Main Menu
 * It can set animations as necessary
*/

public class CharacterController : MonoBehaviour
{
    private GameObject _character;
    private float _characterRotationSpeed;

    void Start()
    {
        // Set _character to whatever gameObject this script is attached to
        _character = this.gameObject;
        SetCharacterAnimation("Idle_A", 0.2f);
        SetRotationSpeed(45f);
    }

    void Update()
    {
        RotateCharacter();
    }

    /* 
     * Set the animation type and speed
     * Attack, Bounce, Clicked, Death, Eat, Fear, Fly, Hit
     * Idle_A, Idle_B, Idle_C, Jump, Roll, Run, Sit, Spin/Splash
     * Swim, Walk
     */

    public void SetCharacterAnimation(string animationName, float animationSpeed)
    {
        int childCount = _character.transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            if (_character.GetComponent<Animator>() != null)
            {
                _character.GetComponent<Animator>().speed = animationSpeed;
                _character.GetComponent<Animator>().Play(animationName);
            }
            else if (_character.transform.GetChild(i).GetComponent<Animator>() != null)
            {
                _character.transform.GetChild(i).GetComponent<Animator>().speed = animationSpeed;
                _character.transform.GetChild(i).GetComponent<Animator>().Play(animationName);
            }
        }
    }

    // Rotation speed in degrees per second
    public void SetRotationSpeed(float rotationSpeed)
    {        
        _characterRotationSpeed = rotationSpeed;        
    }

    // Rotate the character based on _characterRotationSpeed.
    private void RotateCharacter()
    {
        _character.transform.Rotate(0, _characterRotationSpeed * Time.deltaTime, 0);
    }
}