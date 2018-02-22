using UnityEngine;
using UnityEngine.UI;
public class Canon : MonoBehaviour
{
	[SerializeField]
	Text mDebug;

	[SerializeField]
	GameObject mBullet;

	[SerializeField]
	GameObject mFireStart;

	float mPower;
	void Update()
	{
		RotMouseCursor();
		if(Input.GetButtonDown("Fire1"))
		{
			HoldBegin();
		}
		if(Input.GetButton("Fire1"))
		{
			Holding();
		}
		if(Input.GetButtonUp("Fire1"))
		{
			GenerateBullet();
		}
		mDebug.text = "Power" + mPower;
	}
	void RotMouseCursor()
	{
		var pos = MousePosition();
		var vec = pos - transform.position;
		var euler = transform.eulerAngles;
		euler.x = -Mathf.Clamp(Mathf.Rad2Deg * Mathf.Atan2(vec.y, vec.x), 0.0f, 90.0f);
		transform.eulerAngles = euler;
	}
	Vector3 MousePosition()
	{
		var cam = Camera.main;
		var vec =Input.mousePosition;
		vec.z = -cam.transform.position.z;
		return cam.ScreenToWorldPoint(vec);
	}
	void GenerateBullet()
	{
		if(mBullet == null)
		{
			return;
		}
		var rigid = mBullet.GetComponent<Rigidbody>();
		if(rigid == null)
		{
			return;
		}
		rigid.Sleep();
		rigid.MovePosition(mFireStart.transform.position);
		rigid.AddForce(transform.forward * mPower);
	}
	void HoldBegin()
	{
		mPower = 0.0f;
	}
	void Holding()
	{
		mPower += 10.0f;
	}
}
