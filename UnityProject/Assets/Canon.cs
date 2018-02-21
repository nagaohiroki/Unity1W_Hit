using UnityEngine;
using UnityEngine.UI;
public class Canon : MonoBehaviour
{
	[SerializeField]
	Text mDebug;

	[SerializeField]
	GameObject mBullet;

	void Start()
	{
		mBullet.SetActive(false);
	}
	void Update()
	{
		RotMouseCursor();
		if(Input.GetButtonDown("Fire1"))
		{
			GenerateBullet();
		}
	}
	void RotMouseCursor()
	{
		var pos = MousePosition();
		var vec = pos - transform.position;
		mDebug.text = pos.ToString();
		var euler = transform.eulerAngles;
		euler.z = Mathf.Clamp(Mathf.Rad2Deg * Mathf.Atan2(vec.y, vec.x), 0.0f, 90.0f);
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
		var bullet = Instantiate(mBullet);
		bullet.SetActive(true);
		bullet.transform.position = transform.position;
		var rigid = bullet.GetComponent<Rigidbody>();
		rigid.AddForce(transform.forward);
	}
}
