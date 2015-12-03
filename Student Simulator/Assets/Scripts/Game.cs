using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Actions.Core;
using Entity;
using UnityEngine;
using StudentSimulator.SaveSystem;
using Quest.Core;

public class Game
{
    [Save]
    public ActionManager ActionCollection;

    [Save]
    public GameEntityManager Entites;

    [Save]
    public QuestCollection Quests;

    static Game Instance;
    public static Game GetInstance() { return Instance; }

	public static void InitInstance (Game game)
	{
        foreach (var actor in Instance.Entites.Actors)
            SaveExecute(() => actor.Destroy());

        Instance.Entites.Actors.Clear();
		Instance.ActionCollection.Actions.Clear();

		Instance = null;
		GC.Collect();
		Instance = game;

        foreach (var actor in Instance.Entites.Actors)
            SaveExecute(() => actor.Init());

        Instance.ActionCollection.Actions.ForEach(o => o.Init());
	}

	static Game()
	{
		Instance = new Game();
	}

	Game()
	{
		ActionCollection = new ActionManager();
		Entites = new GameEntityManager();
        Quests = new QuestCollection();
	}

	public void Update(float Delta)
	{
		ActionCollection.Update(Delta);
	}

    public void Bind()
    {
        Entites.Bind();
        ActionCollection.Bind();
        Quests.Bind();

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
