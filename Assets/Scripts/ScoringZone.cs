using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;

    public bool isPlayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            scoreTrigger.Invoke(eventData);

            if(isPlayer)
            {
                AudioManager.instance.PlaySFX(3);
            }
            else
            {
                AudioManager.instance.PlaySFX(1);
            }
        }

    }
}
