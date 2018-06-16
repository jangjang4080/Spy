using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public Transform parentTR;          // 생성된 구름이 위치할 부모 트랜스폼
    public Cloud topCloud;              // 맨 위에 있는 구름, 이 구름의 위치를 참고하여 다음 구름을 만든다.

    private GameObject player;

    public void Generate()
    {
        // 맨 위에 있는 구름을 복사한다.
        Cloud clone_cloud = Instantiate(topCloud, parentTR).GetComponent<Cloud>();

        // 맨 위에 있는 구름의 위치를 참고하여 새로운 위치를 결정해준다.
        Vector3 topCloudPos = topCloud.transform.localPosition;
        float max_x = 2.2f;
        float max_y = 2.5f;
        float max_distance_x = 2.5f;

        float random_x = Random.Range(0.5f, max_x);
        float random_y = Random.Range(2.0f, max_y);
        int dir = 1;
        if (topCloudPos.x > 0)
            dir *= -1;

        double distance = GetDistance(new Vector2(topCloudPos.x, topCloudPos.y), new Vector2(random_x * dir, topCloudPos.y));
        float sub_distance = (float)distance - max_distance_x;
        // 거리가 2.5 이하 차이면 그대로, 2.5 이상 차이나면 조정해준다.
        if (sub_distance < 0)
            sub_distance = 0;

        clone_cloud.transform.localPosition = new Vector3((random_x * dir) + (sub_distance * -dir), topCloudPos.y + random_y, topCloudPos.z);

        // 맨 위에 있는 구름을 복사된 구름으로 교체해준다.
        topCloud = clone_cloud;
    }

    double GetDistance(Vector2 p1, Vector2 p2)
    {
        return System.Math.Sqrt(((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y)));
    }

	void Start ()
    {
        this.player = GameObject.Find("cat");
    }
	
	void Update ()
    {
        Vector3 playerPos = this.player.transform.position;
        if (playerPos.y > topCloud.transform.position.y)
        {
            Generate();
        }
    }
}
