using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
	public float mTime{get; private set;}
	[SerializeField]
	Text mTimer;
	bool mIsCount;
	void Update()
	{
		if(mIsCount)
		{
			mTime += Time.deltaTime;
			mTimer.text = TimeSpan.FromSeconds(mTime).ToString();
		}
	}
	public void StartTimer()
	{
		mTime = 0.0f;
		mIsCount = true;
	}
	public void StopTimer()
	{
		mIsCount = false;
	}
}
