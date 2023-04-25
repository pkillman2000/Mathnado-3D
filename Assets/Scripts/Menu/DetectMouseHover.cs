using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseHover : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("Hover");
    }

    private void OnMouseExit()
    {
        Debug.Log("Exit Hover");
    }
}
