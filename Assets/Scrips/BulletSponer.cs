using UnityEngine;

public class BulletSponer : MonoBehaviour
{
    [SerializeField] private GameObject topBorderObj;
    [SerializeField] private GameObject bottomBorderObj;
    [SerializeField] private GameObject leftBorderObj;
    [SerializeField] private GameObject rightBorderObj;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject parentObject;

    [SerializeField] private float spornChance = 0.2f;
    [SerializeField] private float spornRange = 50.0f;
    [SerializeField] private float spornBottomCorrection = 20.0f;

    [SerializeField] private float bottomBorderCorrection = -10.0f;

    private float topBorder;
    private float bottomBorder;
    private float leftBorder;
    private float rightBorder;

    void Start()
    {
        topBorder = topBorderObj.transform.position.y;
        bottomBorder = bottomBorderObj.transform.position.y;
        leftBorder = leftBorderObj.transform.position.x;
        rightBorder = rightBorderObj.transform.position.x;
    }

    void Update()
    {
        if(Random.Range(0.0f, 1.0f) <= spornChance)
        {
            float x = Random.Range(leftBorder, rightBorder);
            float y = topBorder + spornBottomCorrection + Random.Range(0.0f, spornRange);

            GameObject bullet = Instantiate(bulletPrefab,
                new Vector3(x, y, 0.0f),
                Quaternion.identity,
                parentObject.transform);
            bullet.GetComponent<BulletMovement>().bottomBorder = bottomBorder + bottomBorderCorrection;
        }
    }
}
