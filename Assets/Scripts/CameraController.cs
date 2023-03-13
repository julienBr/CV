using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_player.transform.position.x <= 77.9f && _player.transform.position.z <= -0.6f)
        {
            _animator.SetTrigger("FirstToSecond");
            /*transform.position = new Vector3(83.93f, 2.35f, 3.93f);
            transform.rotation = Quaternion.Euler(22.5f,-135f,0f);*/
        }
        else
        {
            _animator.SetTrigger("SecondToFirst");
            /*transform.position = new Vector3(83.93f, 2.35f, -3.93f);
            transform.rotation = Quaternion.Euler(22.5f,-45f,0f);*/
        }
    }
}