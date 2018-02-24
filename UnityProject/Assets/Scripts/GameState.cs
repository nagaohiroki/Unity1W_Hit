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
		ClearWait,
		Clear,
	}
	State mState = State.Game;
	public void DebugLog(string inLog)
	{
		if(mDebug == null)
		{
			return;
		}
		mDebug.text = inLog;
	}
	public void Clear()
	{
		mState = State.ClearWait;
		mResult.gameObject.SetActive(true);
	}
	void Start()
	{
		mResult.gameObject.SetActive(false);
	}
}
