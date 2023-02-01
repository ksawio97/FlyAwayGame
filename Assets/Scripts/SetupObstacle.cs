using UnityEngine;

public class SetupObstacle : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spikes;

    [SerializeField]
    private GameObject pointZone;

    //All y pos
    static float spaceToOnlyTouchEnds = 1.265f;

    static float getRandSpaceBetween
    {
        get
        {
            return Random.Range(0.4f, 0.8f);
        }
    }

    //for spike below
    static float getRandPos
    {
        get
        {
            return Random.Range(-1.345f, -0.32f);
        }
    }

    void Start()
    {
        float pos = getRandPos;
        float space = getRandSpaceBetween;

        MoveSpikes(pos, space);
        PointZoneManagement(pos, space);
    }

    private void MoveSpikes(float pos, float space)
    {
        spikes[0].transform.position = new Vector3(transform.position.x, pos);
        spikes[1].transform.position = new Vector3(transform.position.x, pos + spaceToOnlyTouchEnds + space);
    }

    private void PointZoneManagement(float pos, float space)
    {
        var coll = pointZone.GetComponent<BoxCollider2D>();
        coll.size = new Vector2(coll.size.x, space);
        pointZone.transform.position = new Vector3(transform.position.x, pos + spaceToOnlyTouchEnds / 2 + space / 2);
    }
}
