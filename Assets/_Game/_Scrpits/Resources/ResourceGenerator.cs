using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator: MonoBehaviour
{
    //[SerializeField] protected ResourceName _resourceName;
    [SerializeField] protected List<GameObject> _listBrick;

    [SerializeField] private int _number;

    private void Start()
    {
        Generating();
    }
    private void Update()
    {
        
    }
    protected virtual void Generating()
    {
        _number = Random.Range(0, 5);
        ResourceManager._instance.ChangeColor(_number, transform.gameObject);
    }

}
