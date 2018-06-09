using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

    public Text text;
	GameObject hpGage;

    private float elapsedTime = 0.0f;
    private float addTime = 0.0f;

	void Start() {
		this.hpGage = GameObject.Find("hpGage");

        text.text = "Time : " + elapsedTime.ToString();
    }

	public void DecreaseHp() {
		this.hpGage.GetComponent<Image> ().fillAmount -= 0.5f;
	}

    private void Update()
    {
        addTime += Time.deltaTime;
        if (addTime > 1.0f)
        {
            elapsedTime += addTime;
            text.text = "Time : " + elapsedTime.ToString();

            addTime = 0.0f;
        }
    }
}