using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Actions.Core;
using Entity;

[Serializable]
public class Game
{
	public ActionManager Actions;
	public PoolManager Entites;

	static Game Instance;
	public static Game GetInstance(){return Instance;}

	public static void InitInstance (Game game)
	{
		Instance.Entites.Actor.ForEach( o => o.Destroy());
		Instance.Entites.Actor.Clear();
		Instance.Actions.actions.Clear();
		Instance = null;
		GC.Collect();
		Instance = game;
		Instance.Entites.Actor.ForEach( o => o.Init());
	}

	static Game()
	{
		Instance = new Game();
		Json.Json.SetSeralizationType(Json.Json.SeralizationType.Readable);
	}

	Game()
	{
		Actions = new ActionManager();
		Entites = new PoolManager();
	}

	public void Update(float Delta)
	{
		Actions.Update(Delta);
	}
}