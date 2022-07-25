using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    private Vector2 _direction;

    private void FixedUpdate()
    {
        if(isComputer)
        {
            if (ball.velocity.x > 0.0f)
            {
                if (ball.position.y > transform.position.y)
                {
                    _rigidbody.AddForce(Vector2.up * speed);
                }
                else if (ball.position.y < transform.position.y)
                {
                    _rigidbody.AddForce(Vector2.down * speed);
                }
            }
            else
            {
                if (transform.position.y > 0.0f)
                {
                    _rigidbody.AddForce(Vector2.down * speed);
                }
                else if (transform.position.y < 0.0f)
                {
                    _rigidbody.AddForce(Vector2.up * speed);
                }
            }
        }

        if(isPlayer)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                _direction = Vector2.down;
            }
            else
            {
                _direction = Vector2.zero;
            }

            if (_direction.sqrMagnitude != 0)
            {
                _rigidbody.AddForce(_direction * speed);
            }
        }
    }
}
