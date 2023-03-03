using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : CharacterController
{
    private IState<Character> currentState;

    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform _targetPointWin;  
    [SerializeField] private Transform _targetPoint; // điểm đi đến
    [SerializeField] private Transform _nextTargetPoint;  // điểm target tiếp theo cần tới

    [SerializeField] private List<GameObject> _listBrickTarget;  // list chứa các brick mình cần đi đến
    [SerializeField] private GetColor _getColorCharacter;


    [SerializeField] private PlayerGetBrick _playerGetBrick;  // lấy ra số lượng viên gạch trên lưng

    [SerializeField] private GameObject _listBrick;
    [SerializeField] private FloorController _floorController;  // lấy ra số viên gạch trên sẫn

    [SerializeField] private HolderBrick _holderBrick;
    [SerializeField] public PlayerGetBrick _botGetBrick;
   //  [SerializeField] private List<Transform> _ListPointUnderBridge;
  //  [SerializeField] private List<Transform> _ListPointInsideBridge;
    [SerializeField] private int numberBot;
    public bool _isCheckList = false;
    private int _numBrickRandom;
    private int _numberBrick;
    protected  override  void Start()
    {
        Oninit();
    }

    // Update is called once per frame
    void Update()
    {
      
        
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
        //   Debug.Log("num :" + _numBrick);
        //GetListBrickTarget(_holderBrick._listHolderBrick);
      
        GetListBrickTarget(_listBrick.transform);
    
    }

    protected override void Oninit()
    {
        base.Oninit();
        _numBrickRandom = Random.Range(4, 6);
        navMeshAgent.speed = _moveSpeed;
        _playerGetBrick = _playerGetBrick.GetComponent<PlayerGetBrick>();
        ChangeState(new IdleState());
        
    }

    public override void Move()
    {
        _animatorController.PlayRun();

    }



    public void GoToTargetPoint()
    {
        _numberBrick = _playerGetBrick.GetComponent<PlayerGetBrick>()._stackBrick.Count;
      
        // Tìm kiếm đối tượng vật thể gần nhất
        if (_nextTargetPoint == null || _playerGetBrick._stackBrick.Count <= 0)
        {
            _nextTargetPoint = FindClosestBrick().transform;
        }
        _targetPoint = _nextTargetPoint;

        // Nếu có đối tượng vật thể gần nhất, di chuyển đến nó
        if (_targetPoint != null)
        {
            navMeshAgent.SetDestination(_targetPoint.position);
            _animatorController.PlayRun();
            // Nếu bot đến gần đối tượng vật thể
            if (Vector3.Distance(transform.position, _targetPoint.position) < 1f)
            {
                if (_targetPoint.CompareTag("Brick"))
                {
                     _listBrickTarget.Remove(_targetPoint.gameObject);    // tạm thời loại bỏ brick target ra khỏi brick
                   
                    if (_numBrickRandom > _playerGetBrick._stackBrick.Count)
                    {
                        _nextTargetPoint = FindClosestBrick().transform;
                    }
                    
                    else
                    {
                        _nextTargetPoint = _targetPointWin;
                    }
                }
            }
        }
        else
        {
            _animatorController.PlayIdle();
        }
    }

    //private Transform FindNextTarget()
    //{
    //    if (Vector3.Distance(transform.position, _ListPointUnderBridge[numberBot].transform.position) < 0.5f) 
    //    {
    //        _nextTargetPoint = _ListPointInsideBridge[numberBot].transform;

    //    }
    //    return _nextTargetPoint;
    //}

    public void GetListBrickTarget(Transform transforms)
    {
        if (!_isCheckList || _listBrickTarget.Count < 0)
        {
            Debug.Log(" despawm");
            foreach (Transform child in transforms)
            {
                if (child.gameObject.GetComponent<ResourceGenerator>()._number == _getColorCharacter.GetComponent<GetColor>()._numColor)
                {
                    _listBrickTarget.Add(child.gameObject);
                }
            }
            _isCheckList = true;
        }
    }
    GameObject FindClosestBrick()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestBrick = null;

        foreach (GameObject child in _listBrickTarget)
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
    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public override void StopMoveToForward()
    {
        base.StopMoveToForward();
    }

    public override void ActiveSpeed()
    {
        base.ActiveSpeed();
        navMeshAgent.speed = 4f;
        _animatorController.PlayRun();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            _floorController=  collision.collider.GetComponent<FloorController>();

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            _floorController = collision.collider.GetComponent<FloorController>();
            

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            _floorController = collision.collider.GetComponent<FloorController>();
            //_isCheckList = false;
            //Debug.Log("nothing");
            //List<Transform> list = _floorController.ListBrick();
            //GetListBrickTarget(list);
        }
    }
}
