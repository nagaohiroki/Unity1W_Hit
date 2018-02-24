using UnityEngine;
public class Canon : MonoBehaviour
{
	[SerializeField]
	GameState mState;

	[SerializeField]
	GameObject mBullet;

	[SerializeField]
	GameObject mFireStart;

	[SerializeField]
	Block mBlock;

	float mPower;
	void Game()
	{
		RotMouseCursor();
		if(Input.GetButtonDown("Fire1"))
		{
			mBlock.ResetBlock();
			HoldBegin();
		}
		if(Input.GetButton("Fire1"))
		{
			Holding();
			Scale();
		}
		if(Input.GetButtonUp("Fire1"))
		{
			Fire();
			transform.localScale = Vector3.one;
		}
	}
	void RotMouseCursor()
	{
		var pos = MousePosition();
		var vec = pos - transform.position;
		float angle = Mathf.Clamp(Mathf.Rad2Deg * Mathf.Atan2(vec.y, vec.x), 0.0f, 90.0f);
		var euler = transform.eulerAngles;
		euler.x = -angle;
		transform.eulerAngles = euler;
		mState.DebugLog(string.Format("Power {0}\nAngle {1}", (int)mPower, (int)angle));
	}
	Vector3 MousePosition()
	{
		var cam = Camera.main;
		var vec = Input.mousePosition;
		vec.z = -cam.transform.position.z;
		return cam.ScreenToWorldPoint(vec);
	}
	void Fire()
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
		mBullet.SetActive(true);
		rigid.isKinematic = false;
		rigid.AddForce(transform.forward * mPower);
	}
	void HoldBegin()
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
		rigid.isKinematic = true;
		rigid.transform.position = mFireStart.transform.position;
		mBullet.SetActive(false);
		mPower = 0.0f;
	}
	void Holding()
	{
		mPower += 10.0f;
	}
	void Scale()
	{
		var scale = transform.localScale;
		float power = 1.0f + mPower * 0.0001f;
		scale.x = power;
		scale.y = power;
		scale.z = Mathf.Max(0.1f, 1.0f / (1.0f + mPower * 0.001f));
		transform.localScale = scale;
	}
	void Update()
	{
		switch(mState.mState)
		{
		case GameState.State.GameWait:
		{
			Game();
			break;
		}
		case GameState.State.ClearWait:
		{
			if(mBlock.IsLast())
			{
				if(Input.GetButtonDown("Fire1"))
				{
					HoldBegin();
					mState.Complete();
				}
			}
			else
			{
				if(Input.GetButtonDown("Fire1"))
				{
					HoldBegin();
					mBlock.NextStage();
					mState.Game();
				}
			}
			break;
		}
		case GameState.State.CompleteWait:
		{
			if(Input.GetButtonDown("Fire1"))
			{
				mBlock.InitStage();
				mState.Game();
			}
			break;
		}
		}
	}
}
