using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _anim;
    [SerializeField] private State _currentState;
    [SerializeField] private GameObject _bulletClone;
    [SerializeField] private GameObject _bulletOriginal;
    [SerializeField] private float _timer;
    [SerializeField] private float _speed;
    [SerializeField] private float _collDown;
    [SerializeField] private GameObject shootPoint;

    private void Start()
    {
        _currentState = new Idle(this.gameObject, _anim, _playerTransform, _bulletClone);
    }
    private void Update()
    {
        if (_currentState.CanAttackPlayer() && _timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else if (_currentState.CanAttackPlayer() && _timer < 0)
        {
            _bulletClone = Instantiate(_bulletClone, shootPoint.transform.position, this.transform.rotation);
            _bulletClone.AddComponent<Bullet>().player = _playerTransform;
            _bulletClone.GetComponent<Bullet>()._speed = _speed;
            _bulletClone.GetComponent<Bullet>()._timer = 5.0f;
            _bulletClone.GetComponent<Bullet>()._coolDown = 5.0f;
            _bulletClone = _bulletOriginal;
            _timer = _collDown;
        }
        else
        {
            _timer = _collDown;
        }
            _currentState = _currentState.Process();
    }
}
