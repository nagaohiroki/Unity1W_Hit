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
		Clear,
	}
	public void DebugLog(string inLog)
	{
		if(mDebug == null)
		{
			return;
		}
		mDebug.text = inLog;
	}
	void Update()
	{
	}
}
