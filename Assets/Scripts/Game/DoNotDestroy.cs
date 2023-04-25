using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script will stop whatever tag is entered from
 * being destroyed.
*/

public class DoNotDestroy : MonoBehaviour
{
    [SerializeField]
    private string _objectTag;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(_objectTag);
        
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
