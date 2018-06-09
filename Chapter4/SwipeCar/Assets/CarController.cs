using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
    public Transform car_sprite;
    public AudioSource completeSound;

	float speed = 0;
	Vector2 startPos;
    Vector2 initPos;

    bool isInput = false;

	void Start()
    {
        initPos = transform.localPosition;
	}

	void Update() {

        // 스와이프 길이를 구한다 (추가)
        if (Input.GetMouseButtonDown(0)) {
            // 마우스를 클릭한 좌표
            this.startPos = Input.mousePosition;

        } else if(Input.GetMouseButtonUp(0)) {
            // 마우스를 떼었을 때 좌표
            Vector2 endPos = Input.mousePosition;
			float swipeLength = (endPos.x - this.startPos.x);

            // 스와이프 길이를 처음 속도로 변경한다
            this.speed = swipeLength / 500.0f;

			// 효과재생음(추가)
			GetComponent<AudioSource>().Play();

            isInput = true;
        }

        //Debug.Log(this.speed);

		transform.Translate(this.speed, 0, 0);
		this.speed *= 0.98f;

        if (isInput)
        {
            if (this.speed <= 0.005f)
            {
                completeSound.Play();
                isInput = false;
            }
        }

        if (transform.localPosition.x <= -7.7f)
        {
            transform.localPosition = new Vector3(-7.7f, transform.localPosition.y, transform.localPosition.z);
            this.speed = 0;
        }
        else if (transform.localPosition.x >= 7.7f)
        {
            transform.localPosition = new Vector3(7.7f, transform.localPosition.y, transform.localPosition.z);
            this.speed = 0;

            FlyCar();
        }
	}

    void FlyCar()
    {
        completeSound.Play();
        isInput = false;

        transform.Translate(0, 0.1f, 0);
        car_sprite.transform.Rotate(0.0f, 0.0f, 5.0f);
        if (transform.localPosition.y >= 20.0f)
            ResetCar();
    }

    void ResetCar()
    {
        transform.localPosition = initPos;
        car_sprite.transform.localRotation = Quaternion.identity;
    }
}
