using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;

    public float speed = 10;
    protected Rigidbody2D _rigidbody;

    public bool isPlayer, isComputer;

    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        _rigidbody.position = new Vector2(_rigidbody.position.x, 0.0f);
        _rigidbody.velocity = Vector3.zero;
    }
}
