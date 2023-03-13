using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Update()
    {
        if (_player.transform.position.x <= 77.9f && _player.transform.position.z <= -0.6f)
        {
            transform.position = new Vector3(83.93f, 2.35f, 3.93f);
            transform.rotation = Quaternion.Euler(22.5f,225f,0f);
        }
        else
        {
            transform.position = new Vector3(83.93f, 2.35f, -3.93f);
            transform.rotation = Quaternion.Euler(22.5f,-45f,0f);
        }
    }
}