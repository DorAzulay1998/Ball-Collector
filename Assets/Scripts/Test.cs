using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    string playerName = "Frank";
    void Start()
    {
        Debug.Log("Hello: " + gameObject.name + playerName);
    }
}
