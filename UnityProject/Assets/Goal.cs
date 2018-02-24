using UnityEngine;
using UnityEngine.UI;
public class Goal : MonoBehaviour 
{
	void OnCollisionEnter(Collision inColl)
	{
		if(inColl.gameObject.tag == "Ground")
		{
			Debug.Log("Clear");
		}
	}
}
