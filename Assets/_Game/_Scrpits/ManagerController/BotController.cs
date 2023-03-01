using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotController : CharacterController
{
    [SerializeField] Transform _underBrigde;
    [SerializeField] Transform _inTheBrigde;
    [SerializeField] Transform _targetWin;

    [SerializeField] private GameObject _listBrick_1;
    [SerializeField] private GameObject _listBrick_2;
    [SerializeField] private GetColor _getColorCharacter;
    [SerializeField] private PlayerGetBrick _playerGetBrick;
    public List<GameObject> _targetTranforms;
    public GameObject _target;
    bool _isCheckList = false;
    bool _isDestination = false;
    private NavMeshAgent _agent;

    public GameObject _nextTarget;
    protected override void Start()
    {
        base.Start();
        _agent = GetComponent<NavMeshAgent>();
        _playerGetBrick = _playerGetBrick.GetComponent<PlayerGetBrick>();
        
    }

    void Update()
    {
        //  Debug.Log(Vector3.Distance(transform.position, _underBrigde.position));
        GetTargetToList();
        // Tìm kiếm đối tượng vật thể gần nhất
     //   Debug.Log(_playerGetBrick._stackBrick.Count);
        if (_nextTarget == null || _playerGetBrick._stackBrick.Count <= 0)
        {
            _nextTarget = FindClosestFood();
        }
        _target = _nextTarget;
        
        // Nếu có đối tượng vật thể gần nhất, di chuyển đến nó
        if (_target != null)
        {
            _agent.SetDestination(_target.transform.position);
            _animatorController.PlayRun();
            // Nếu bot đến gần đối tượng vật thể
            if (Vector3.Distance(transform.position, _target.transform.position) < 1f)
            {
                if (_target.CompareTag("Brick"))
                {
                    _targetTranforms.Remove(_target.gameObject);
                    //Destroy(_target);

                    _target.SetActive(false);
                }

                if (Vector3.Distance(transform.position , _underBrigde.position) < 0.5f)
                {

                    _nextTarget = _inTheBrigde.gameObject;
                    //_isCheckList = false;
                    Debug.Log("ênne");
                }
                //if (Vector3.Distance(transform.position, _inTheBrigde.position) < 0.5f)
                //{
                //    _targetTranforms.Clear();
                //    _listBrick_1 = _listBrick_2;
                //    _isCheckList = false;
                //    GetTargetToList();
                //    _nextTarget = FindClosestFood();
                //}
                else
                {
                    _nextTarget = SearchTarget();
                }
            }
        }
        else
        {
            _animatorController.PlayIdle();
        }
    }

    private void GetTargetToList()
    {
        if (!_isCheckList)
        {
            foreach (Transform child in _listBrick_1.transform)
            {
                if (child.gameObject.GetComponent<ResourceGenerator>()._number == _getColorCharacter.GetComponent<GetColor>()._numColor && child.gameObject.activeSelf == true)
                {
                    _targetTranforms.Add(child.gameObject);
                }
            }
            _isCheckList = true;
        }
    }

    // vật thể gần nhất với đối ttuwojng
    GameObject FindClosestFood()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestBrick = null;

        foreach (GameObject child in _targetTranforms)
        {
            float distance = Vector3.Distance(transform.position, child.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestBrick = child;
            }
        }

        return closestBrick;
    }


    private GameObject SearchTarget()
    {
        if (!CheckDestination())
        {
           // int num = Random.Range(2, 6);
            if (_playerGetBrick._stackBrick.Count >= 4)
            {
                return _underBrigde.gameObject;
            }
            else
            {
                return FindClosestFood();
            }
        }
        else
        {
            return FindClosestFood();
        }
    }


    bool CheckDestination()
    {
        if (Vector3.Distance(transform.position, _underBrigde.position) < 0.1f)
        {
            _isDestination = true;
        }
        else
        {
            _isDestination = false;
        }
        return _isDestination;
    }
}
