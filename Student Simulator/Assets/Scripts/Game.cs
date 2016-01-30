using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Actions.Core;
using Entity;
using UnityEngine;
using StudentSimulator.SaveSystem;

public class Game
{
    [Save]
    public ActionCollection ActionCollection;

    [Save]
    public GameEntityCollection EntityCollection;

    static Game Instance;
    public static Game GetInstance() 
    { 
        return Instance; 
    }

	public static void Load (Game game)
	{
        foreach (var actor in Instance.EntityCollection.Actors)
            SaveExecute(() => actor.Destroy());

        Instance.EntityCollection.Actors.Clear();
		Instance.ActionCollection.Actions.Clear();

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
		ActionCollection = new ActionCollection();
		EntityCollection = new GameEntityCollection();
	}

	public void Update(float Delta)
	{
		ActionCollection.Update(Delta);
	}

    public void Bind()
    {
        EntityCollection.Bind();
        ActionCollection.Bind();

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
