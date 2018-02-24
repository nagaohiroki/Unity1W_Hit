using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
	[SerializeField]
	List<GameObject> mBlocks;
	GameObject mStageInstance;
	int mStage;
	public void NextStage()
	{
		mStage += 1;
		ResetBlock();
	}
	public void InitStage()
	{
		mStage = 0;
		ResetBlock();
	}
	public bool IsLast()
	{
		return mStage >= mBlocks.Count -1;
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
	void Start()
	{
		foreach(var block in mBlocks)
		{
			block.SetActive(false);
		}
		ResetBlock();
	}
}
