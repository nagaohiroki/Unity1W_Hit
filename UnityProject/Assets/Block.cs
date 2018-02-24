using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
	[SerializeField]
	List<GameObject> mBlocks;
	GameObject mStageInstance;
	public int mStage;
	public void NextStage()
	{
		mStage += 1;
		mStage = Mathf.Clamp(mStage, 0, mBlocks.Count);
	}
	void Start()
	{
		foreach (var block in mBlocks)
		{
			block.SetActive(false);
		}
		ResetBlock();
	}
	public void ResetBlock()
	{
		if(mStageInstance != null)
		{
			Destroy(mStageInstance);
		}
		if(mStage < 0 || mStage >= mBlocks.Count)
		{
			return;
		}
		var block = mBlocks[mStage];
		mStageInstance = Instantiate(block);
		mStageInstance.SetActive(true);
	}
}
