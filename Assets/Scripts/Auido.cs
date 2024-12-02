using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auido : MonoBehaviour
{
    void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
