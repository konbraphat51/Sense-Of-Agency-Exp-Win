using UnityEngine;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private GameObject directorObj;
    private PointManagement director;

    void Start()
    {
        director = directorObj.GetComponent<PointManagement>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("ontrigger");
        if(collider.tag == "Bullet")
        {
            Hitted();
            Debug.Log("hittted");
        }
    }

    private void Hitted()
    {
        director.Hitted();
    }
}
