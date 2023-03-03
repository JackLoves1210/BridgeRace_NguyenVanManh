using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator: MonoBehaviour
{
    [SerializeField] public int _number;
    [SerializeField] private int _numberCharacter;
    
    private void Start()
    {
       Generating();
    }
    private void Update()
    {
      
    }

    public virtual void Generating()
    {
        // _number = Random.Range(0, 5);
       // do
       // {
            _number = Random.Range(0, _numberCharacter);
     //   } while (BrickManagerment.arr1[_number] == 39);

        ResourceManager._instance.ChangeColor(_number, transform.gameObject);
       // BrickManagerment.arr1[_number]++;
    }
}
