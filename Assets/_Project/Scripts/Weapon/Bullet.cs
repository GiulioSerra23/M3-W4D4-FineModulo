
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeSpan;

    private Rigidbody2D _rb;
    private PlayerController _player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GetComponentInParent<PlayerController>();
    }

    private void Start()
    {
        Destroy(gameObject, _lifeSpan);
    }

    public void SetUp(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }

    private void RotateAnimation()
    {
        transform.Rotate(0, 0, 360 * (_speed * Time.deltaTime));
    }

    private void Update()
    {
       RotateAnimation();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (!collision.collider.TryGetComponent<Enemy>(out var enemy)) return;

        if (!enemy.TryGetComponent<LifeController>(out var lifeController)) return;

        int totalDamage = _player.Damage + _damage;
        enemy.Hit(totalDamage);

        if (lifeController.Hp <= 0)
        {
            enemy.Die();
            KillManager.Instance.OnKill(enemy.transform.position);
        }
    }
}
