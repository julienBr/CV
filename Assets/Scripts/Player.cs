using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 target;
    private int _floorLayer;

    private void Awake()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _floorLayer = LayerMask.NameToLayer("Floor");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Move();
    }

    private void Move()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject.layer.CompareTo(_floorLayer) == 0)
        {
            target = hit.point;
            StartCoroutine(Walk());
        }
    }

    private IEnumerator Walk()
    {
        do
        {
            _agent.SetDestination(target);
            _animator.SetBool("Walk", true);
            yield return null;
        } while (Vector3.Distance(transform.position, target) > 0.1f);
        _animator.SetBool("Walk", false);
    }
}