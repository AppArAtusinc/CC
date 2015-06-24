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
	public GameEntityManager Entites;

	static Game Instance;
	public static Game GetInstance(){return Instance;}

	public static void InitInstance (Game game)
	{
		while (Instance.Entites.Actor.Count != 0)
			Instance.Entites.Actor.First().Destroy();

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
		Entites = new GameEntityManager();
	}

	public void Update(float Delta)
	{
		Actions.Update(Delta);
	}
}