using UnityEngine;
public class Test : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		
		var vec =Input.mousePosition;
		vec.z = -Camera.main.transform.position.z;
		var pos = Camera.main.ScreenToWorldPoint(vec);
		transform.position = pos;
	}
}
