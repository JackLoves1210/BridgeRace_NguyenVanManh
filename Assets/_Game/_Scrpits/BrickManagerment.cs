using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManagerment : MonoBehaviour
{
    [SerializeField] private ResourceGenerator _resourceGenerator;
    [SerializeField] private int _numberBrick;
    public static int[] arr1 = new int[5];

    private void Start()
    {
       // ShowAllChidlren();
    }


    private void Update()
    {
        
    }
    private void ShowAllChidlren()
    {
        foreach (Transform child in transform)
        {
            do
            {
              _resourceGenerator._number = Random.Range(0, 4);
            } while (arr1[_resourceGenerator._number] == 16);

            ResourceManager._instance.ChangeColor(_resourceGenerator._number, child.gameObject);
            arr1[_resourceGenerator._number]++;
            

        }
        
    }
        
}
