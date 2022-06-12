using System.Collections;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
public class BotMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _botSpeed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private bool _isMovable;
    [SerializeField] private bool _isLoock;
    [SerializeField] private bool _isAnimated;

    private UnityEngine.AI.NavMeshAgent _agent;
    private Animator _enemyAnimation;
    private bool _moved = false;

    private void Start()
    {
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _enemyAnimation = GetComponentInChildren<Animator>();
        _agent.stoppingDistance = _stopDistance;
        _agent.speed = _botSpeed;
    }

    private void Update()
    {
        if(_isMovable)
            _agent.destination = _player.position;

        if (_isLoock)
        {
            transform.LookAt(_player.transform);
        }


        if (_isAnimated)
        {
            if (_agent.velocity != Vector3.zero)
            {
                _moved = true;
                _enemyAnimation.SetBool("isMoved", _moved);
            }
            else
            {
                _moved = false;
                _enemyAnimation.SetBool("isMoved", _moved);
            }
        }       
    }
}
