using UnityEngine;
using System.Collections;

public class RouletteController : MonoBehaviour
{
    public AudioSource rotSound;
    public AudioSource completeSound;

    bool isStart = false;
	float rotSpeed = 0; // 회전속도

    void Start()
    {
        
	}

	void Update() {
        // 마우스가 눌리면 회전 속도를 설정한다
        if (Input.GetMouseButtonDown(0)) {
			this.rotSpeed = 50;
            rotSound.Play();

            isStart = true;
        }

        // 회전 속도만큼 룰렛을 회전 시킨다
        transform.Rotate(0, 0, this.rotSpeed);

        // 룰렛을 감속시킨다 (추가)
        this.rotSpeed *= 0.99f;

        Debug.Log(this.rotSpeed);

        if (isStart)
        {
            if (this.rotSpeed < 0.1f)
            {
                completeSound.Play();

                isStart = false;
            }
            else if (this.rotSpeed < 5.0f)
            {
                rotSound.Stop();
            }
        }
	}
}