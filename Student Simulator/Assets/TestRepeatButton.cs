using UnityEngine;
using System.Collections;
using Actions;
using Actions.Core;


public class TestRepeatButton : Button
{

    public override void Clicked(GameObject Sender)
    {
        GameAction.Stop("Test Action");
        var cube = GameObject.Find("Test Cube 2");

        new Repeat(
            new MoveTo(cube, new Vector3(-5, 0.5f, -5)).SetDuration(2),
            new MoveTo(cube, new Vector3(-10, 0.5f, -5)).SetDuration(1),
            new MoveTo(cube, new Vector3(-10, 0.5f, 5)).SetDuration(1),
            new MoveTo(cube, new Vector3(-5, 0.5f, 5)).SetDuration(1),
            new MoveTo(cube, new Vector3(-5, 0.5f, -5)).SetDuration(1),
            new MoveTo(cube, new Vector3(-20, 0.5f, -20)).SetDuration(2)
        ).
        SetRepeatCount(2).
        SetName("Test Action").
        Run();
    }
}
