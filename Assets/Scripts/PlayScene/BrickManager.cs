using UnityEngine;
using System.Collections.Generic;

public class BrickManager: MonoBehaviour 
{
	public enum BrickType
    {
		Normal,
		MultiHit,
    }

	public PongManager sceneManager;

	public GameObject[] brickPrefabs;
	public GameObject BrickContainer;

	private List<Brick> Bricks = new List<Brick>();

	void Start () 
	{

		
	}

	public void CreateBricks(List<BrickScript> brickScripts)
	{
		foreach (var script in brickScripts)
		{
			Brick brick = CreateBrick(script.brickType, script.position);

			if (brick != null)
			{
				brick.brickManager = this;
				Bricks.Add(brick);
			}
		}
	}

	public Brick CreateBrick(BrickType type, Vector2 pos)
    {
		var go = Instantiate(brickPrefabs[(int)type], BrickContainer.transform);
		Brick brick = go.GetComponent<Brick>();
		brick.SetPosition(pos);

		return brick;
	}


	public void DestroyBrick(Brick brick)
    {
		if (Bricks.Contains(brick))
        {
			Bricks.Remove(brick);
			Destroy(brick.gameObject);
		}

		if (Bricks.Count == 0)
        {
			sceneManager.Finish();
		}
    }
}


public class BrickScript
{
	public BrickManager.BrickType brickType;
	public Vector2 position;

	public BrickScript(int type, Vector2 pos)
	{
		brickType = (BrickManager.BrickType)type;
		position = pos;
	}
}
