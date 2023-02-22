using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColor : MonoBehaviour
{
    [SerializeField] public int _numColor;

    private void Start()
    {
        Oninit();
    }

    private void Oninit()
    {
        GetColorCharacter();
    }
    private void GetColorCharacter()
    {
        ResourceManager._instance.ChangeColor(_numColor, transform.gameObject);
    }
}
