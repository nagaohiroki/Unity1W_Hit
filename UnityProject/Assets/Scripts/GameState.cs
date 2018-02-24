using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
	[SerializeField]
	Text mDebug;
	[SerializeField]
	Text mResult;
	public enum State
	{
		Game,
		GameWait,
		Clear,
		ClearWait,
		Complete,
		CompleteWait,
	}
	public State mState = State.Game;
	float mWait;
	public void DebugLog(string inLog)
	{
		if(mDebug == null)
		{
			return;
		}
		mDebug.text = inLog;
	}
	public void Complete()
	{
		mState = State.Complete;
		mResult.text = "COMPLETE!!";
		mResult.gameObject.SetActive(true);
		mWait = 0.0f;
	}
	public void Clear()
	{
		mState = State.Clear;
		mResult.text = "CLEAR!!";
		mResult.gameObject.SetActive(true);
		mWait = 0.0f;
	}
	public void Game()
	{
		mState = State.Game;
		mResult.gameObject.SetActive(false);
		mWait = 0.0f;
	}
	void Wait(State inState, State inWaitState)
	{
		if(mState == inState)
		{
			mWait += Time.deltaTime;
			if(mWait >= 0.5f)
			{
				mState = inWaitState;
			}
		}
	}
	void Start()
	{
		mResult.gameObject.SetActive(false);
	}
	void Update()
	{
		Wait(State.Clear, State.ClearWait);
		Wait(State.Complete, State.CompleteWait);
		Wait(State.Game, State.GameWait);
	}
}
