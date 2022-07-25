using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrenght;

    public bool isPaddle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if(ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * bounceStrenght);

            if (isPaddle)
            {
                AudioManager.instance.PlaySFX(2);
            }
            else
            {
                AudioManager.instance.PlaySFX(0);
            }
        }
    }
}
