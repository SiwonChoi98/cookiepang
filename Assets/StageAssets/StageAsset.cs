using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public enum ScoreMode
{
    BallCount,
    Score
}

public enum GameMode
{
    Default,
    HoleIn,
    Candy,
    Macaroon
}

public abstract class StageAsset : ScriptableObject
{
    public ScoreMode scoreMode;
    
    public GameMode gameMode;
    public List<BlockData> blocks;

    public int initailBallCount;
    public int[] stars = new int[3];

    public StageAsset()
    {
        scoreMode = ScoreMode.BallCount;
        gameMode = GameMode.Default;
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }

    public virtual void Initialize()
    {
        GameManager.instance.initialBallCount = initailBallCount;
        GameManager.instance.ballCount = initailBallCount;
        GameManager.instance.deadLineMaxBallCount = initailBallCount;
        GameManager.instance.DeadLineCount();

        foreach (var block in blocks)
        {
            var instance = GameManager.instance.CreateBlock(block.type, block.row, block.col);
            instance.GetData(block);
        }
    }

    public virtual void Update()
    {

    }
    public abstract bool IsClear();

    public virtual bool IsOver()
    {
        return false;
    }
    public virtual int GetStars()
    {
        int starCount = 0;
        foreach (var deadline in stars)
        {
            if (deadline < GameManager.instance.ballCount)
            {
                starCount++;
            }
        }
        return starCount;
    }

    public virtual string GetGoal()
    {
        return "<size=150%><voffset=0.2em><sprite=0></voffset></size>";
    }
}
