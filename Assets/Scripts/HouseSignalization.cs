using UnityEngine;

public class HouseSignalization : MonoBehaviour
{
    [SerializeField] private AudioSource _signalization;
    [SerializeField] private float _speed;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    private bool _isUp;
    
    private void Start()
    {
        _isUp = true;
        _signalization.volume = _minVolume;
    }

    private void Update()
    {
        if (_signalization.isPlaying && _isUp)
        {
            _signalization.volume = Mathf.MoveTowards(_signalization.volume, _maxVolume, _speed * Time.deltaTime);
        }
        else if (_isUp == false)
        {
            _signalization.volume = Mathf.MoveTowards(_signalization.volume, _minVolume, _speed * Time.deltaTime);
            if (_signalization.volume == _minVolume)
                _signalization.Stop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player) && !_signalization.isPlaying)
        {
            _signalization.Play();
            _isUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isUp = false;
    }
}
