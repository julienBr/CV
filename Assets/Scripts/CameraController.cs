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
             _animator.SetBool("ChangeAngle", true);
        else _animator.SetBool("ChangeAngle", false);
    }
}