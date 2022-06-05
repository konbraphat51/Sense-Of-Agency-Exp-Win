using UnityEngine;
using UnityEngine.UI;

public class PointManagement : MonoBehaviour
{
    [SerializeField] private GameObject pointDisplyObj;
    private Text pointDisply;
    [SerializeField] private GameObject highScoreDisplyObj;
    private Text highScoreDisply;

    private float pointStartTime = 0.0f;
    [SerializeField] private float pointMultiply = 100.0f;
    private int point = 0;
    private int highScore = 0;

    void Start()
    {
        pointStartTime = Time.time;

        pointDisply = pointDisplyObj.GetComponent<Text>();
        highScoreDisply = highScoreDisplyObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate time
        point = (int)((Time.time - pointStartTime)*pointMultiply);

        if(point > highScore)
        {
            highScore = point;
        }

        //Edit UI
        ShowPoint();
    }

    public void Hitted()
    {
        pointStartTime = Time.time;
    }

    private void ShowPoint()
    {
        pointDisply.text = point.ToString();
        highScoreDisply.text = highScore.ToString();
    }
}
