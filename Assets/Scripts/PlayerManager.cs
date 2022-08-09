using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] Joystick _joystick;

    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = _joystick.Horizontal;// Input.GetAxisRaw("Horizontal");
        float vertical = _joystick.Vertical;// Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            var dir = (direction * Time.deltaTime * speed);
            _rigidbody.velocity = new Vector3(dir.x, _rigidbody.velocity.y, dir.z);
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
