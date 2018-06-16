using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text text;
    private GameObject player;
    private StringBuilder sb;

    void Start ()
    {
        player = GameObject.Find("cat");
        sb = new StringBuilder();
    }
	
	void Update ()
    {
        double height = System.Math.Round(player.transform.localPosition.y * 10, 2);

        // 최적화
        //sb.Length = 0;
        //text.text = sb.AppendFormat("Height : {0} m", 45 + height).ToString();

        text.text = "Height : " + (45 + height) + "m";
    }
}
