using UnityEngine;

public class DelayManagement : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    private PlayerMovement player;

    [SerializeField] private float delayingTime = 30.0f;
    private float delayStopTime;

    private bool delaying = true;

    void Start()
    {
        player = playerObj.GetComponent<PlayerMovement>();
        delaying = player.IsDelaying();
        delayStopTime = Time.time + delayingTime;
    }

    void Update()
    {
        if(Time.time >= delayStopTime)
        {
            StopDelay(false);
        }
    }

    private void StopDelay(bool shouldDelay)
    {
        player.Delay(shouldDelay);
    }
}
