using UnityEngine;
public class Goal : MonoBehaviour 
{
	[SerializeField]
	GameState mState;
	void OnCollisionEnter(Collision inColl)
	{
		if(inColl.gameObject.tag == "Ground")
		{
			mState.Clear();
		}
	}
}
