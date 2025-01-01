using UnityEngine;
using System;

public class GlobalStructs : MonoBehaviour
{
    
}

[System.Serializable]
public struct StringAndGameObject
{
    public string name;
    public GameObject obj;
}