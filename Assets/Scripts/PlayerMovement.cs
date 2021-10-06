using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private Vector3 _startScale;
    private Vector3 _mirroredScale;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startScale = transform.localScale;
        _mirroredScale = new Vector3(_startScale.x * -1, _startScale.y);
    }

    private void FixedUpdate()
    {
        float route = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.A))
        {
            transform.localScale = _mirroredScale;
            _rigidbody2D.velocity = new Vector3(_speed * -1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = _startScale;
            _rigidbody2D.velocity = new Vector3(_speed, 0, 0);
        }
        if (route < 0)
            route *= -1;
        _animator.SetFloat("Speed", _speed * route);
    }
}
