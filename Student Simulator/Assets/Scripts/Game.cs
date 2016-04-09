using System;
using Actions.Core;
using Entites;
using UnityEngine;
using StudentSimulator.SaveSystem;
using Quest.Common.Core;

public class Game
{
    /// <summary>
    /// Holds collection with actions.
    /// </summary>
    /// <owner>Stanislav Silin</owner>
    [Save]
    public ActionCollection ActionCollection;

    /// <summary>
    /// Holds collection with entities.
    /// </summary>
    /// <owner>Stanislav Silin</owner>
    [Save]
    public GameEntityCollection EntityCollection;

    /// <summary>
    /// Holds collection with quest.
    /// </summary>
    /// <owner>Stanislav Silin</owner>
    [Save]
    public QuestCollection QuestCollection;

    /// <summary>
    /// Indicates is game already loaded.
    /// </summary>
    /// <owner>Stanislav Silin</owner>
    public bool IsLoaded
    {
        get;
        set;
    }

    public static Game Instance;
    public static Game GetInstance() 
    { 
        return Instance; 
    }

    /// <summary>
    /// Loads game.
    /// </summary>
    /// <owner>Stanislav Silin</owner>
    /// <param name="game">The new game.</param>
	public static void ReplaceInstance (Game game)
	{
        foreach (var actor in Instance.EntityCollection.Actors)
            SaveExecute(() => actor.Destroy());

        Instance.EntityCollection.Clear();
		Instance.ActionCollection.Clear();
		Instance.QuestCollection.Clear();

        Instance = null;
		GC.Collect();
		Instance = game;
	}

	static Game()
	{
		Instance = new Game();
	}

	Game()
	{
		this.ActionCollection = new ActionCollection();
		this.EntityCollection = new GameEntityCollection();
        this.QuestCollection = new QuestCollection();
        this.IsLoaded = false;
	}

	public void Update(float Delta)
	{
		ActionCollection.Update(Delta);
	}

    public void Bind()
    {
        EntityCollection.Bind();
        ActionCollection.Bind();

        IsLoaded = true;

        //SaveSystem.Save("The_Origin");
        //SaveSystem.Load("The_Origin");
    }

    public static void SaveExecute(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}