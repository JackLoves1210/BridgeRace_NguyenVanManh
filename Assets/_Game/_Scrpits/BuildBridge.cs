using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _step;
    [SerializeField] private Transform _brigde;
    [SerializeField] private LayerMask _BRIDGE_LAYER;

    private bool _isHaveStep;
    private void Update()
    {
        BuildStair();
    }

    private void BuildStair()
    {
        
        Ray ray = new Ray(_player.position + new Vector3(0,0.5f,0.25f), Vector3.down);
        Debug.DrawLine(_player.position + new Vector3(0, 0.5f, 0.5f), _player.position + new Vector3(0, 0, 0.25f) + Vector3.down * 50f, color: Color.red);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit, 50f,_BRIDGE_LAYER);
        Debug.Log(isHit);
        if (isHit)
        {
            if (hit.collider != null && hit.collider.tag == "Stair")
            {
                _isHaveStep = true;
                Debug.Log("Not spawn");
            }
            else if (hit.collider != null)
            {
                Debug.Log("spawned");
                _isHaveStep = false;
                GameObject obj = Instantiate(_step, new Vector3(0f,hit.point.y,hit.point.z + 0.25f) , Quaternion.identity);
                obj.gameObject.transform.SetParent(_brigde);
            }
            else
                _isHaveStep = false; 

        }
        
        
    }

}
