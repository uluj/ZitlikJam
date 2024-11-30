using UnityEngine;


public class FlyingEnemy : Enemies
{
    [SerializeField] private Vector2 flyPos;
    [SerializeField] private float flySpeed = 2f;
    [SerializeField] private float hitSpeed = 1.5f;
    [SerializeField] private float targetRadius = 0.2f;
    [SerializeField] private float randomX;
    [SerializeField] private float randomY;

    private Rigidbody2D _rb;
    private bool _isFlying;
    private bool _isHit;
    private int _currentPath;
    private Transform _player;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Debug.Log(_isFlying);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, targetRadius);
        foreach (var hitColliders in colliders)
        {
            if (hitColliders.transform.CompareTag("Player"))
            {
                if (!_isFlying)
                {
                    //Debug.Log("Player Hit");
                    _player = hitColliders.transform;
                    flyPos = new Vector2(Random.Range(-randomX, randomX), Random.Range(-randomY, randomY));
                    _isFlying = true;
                }
            }
        }

        if (_isFlying)
        {
            if (Vector2.Distance(transform.position, flyPos) < .3f && !_isHit)
            {
                //Debug.Log("is flying");
                _isHit = true;
            }

            if (!_isHit)
            {
                Vector2 flyPosition = Vector2.Lerp(transform.position, flyPos, flySpeed * Time.deltaTime);
                _rb.MovePosition(flyPosition);
                _rb.gravityScale = 0;
            }
            else if (_isHit)
            {
                transform.position = Vector2.Lerp(transform.position, _player.position, hitSpeed * Time.deltaTime);
                //Debug.Log("is hit");
                if (Vector2.Distance(transform.position,_player.position)<.5f)
                {
                    _isHit = false;
                    _isFlying = false; 
                }
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetRadius);
    }
}