using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{
    public static ResourceManager _instance;

    [SerializeField] public List<Resource> _resources;

    protected void Awake()
    {
        if (ResourceManager._instance != null) Debug.LogError("On 1 Resource Only");
        ResourceManager._instance = this;
    }

    public void ChangeColor(int _number , GameObject _gameObject)
    {
        _gameObject.GetComponent<Renderer>().material = _resources[_number]._material;
    }

  
    
}
