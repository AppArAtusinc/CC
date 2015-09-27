using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Actions.Core;
using Entity;
using UnityEngine;

[Serializable]
public class Game
{
	public ActionManager ActionManager;
	public GameEntityManager Entites;

	static Game Instance;
	public static Game GetInstance(){return Instance;}

	public static void InitInstance (Game game)
	{
        Instance.Entites.Actor.ForEach(o => o.Destroy());
        Instance.Entites.Actor.Clear();
		Instance.ActionManager.Actions.Clear();

		Instance = null;
		GC.Collect();
		Instance = game;
		Instance.Entites.Actor.ForEach( o => o.Init());
        LinkToGameEntity.Link();
	}

	static Game()
	{
		Instance = new Game();
		Json.Json.SetSeralizationType(Json.Json.SeralizationType.Readable);
	}

	Game()
	{
		ActionManager = new ActionManager();
		Entites = new GameEntityManager();
	}

	public void Update(float Delta)
	{
		ActionManager.Update(Delta);
	}
}