using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1.0f;

    public float bottomBorder = -460.0f;

    void Update()
    {
        transform.position += new Vector3(0.0f, -bulletSpeed, 0.0f);

        if(transform.position.y <= bottomBorder)
        {
            Destroy(gameObject);
        }
    }
}
