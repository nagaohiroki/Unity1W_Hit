using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
	[SerializeField]
	Text mTimer;
	[SerializeField]
	Text mRecord;
	bool mIsCount;
	float mTime;
	float mTotalTime;
	int mStage;
	public void StartTimer()
	{
		if(mIsCount)
		{
			return;
		}
		mTime = 0.0f;
		mIsCount = true;
	}
	public void StopTimer()
	{
		if(!mIsCount)
		{
			return;
		}
		mIsCount = false;
		++mStage;
		mTotalTime += mTime;
		mRecord.text += string.Format("Stage{0}: {1}\n", mStage, TimeSpan.FromSeconds((int)mTime));
	}
	public void Total()
	{
		mRecord.text += string.Format("Total: {0}\n", TimeSpan.FromSeconds((int)mTotalTime));
	}
	public void Reset()
	{
		mRecord.text = string.Empty;
		mTimer.text = string.Empty;
		mStage = 0;
		mTotalTime = 0;
	}
	void Start()
	{
		Reset();
	}
	void Update()
	{
		if(mIsCount)
		{
			mTime += Time.deltaTime;
			TimeSpan span = TimeSpan.FromSeconds((int)mTime);
			mTimer.text = span.ToString();
		}
	}
}
