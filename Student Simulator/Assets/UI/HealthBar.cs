using UnityEngine;
using System.Collections;
using System.Linq;
using Entites;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    protected Image img;
    Player player;

    void Start()
    {
        StartCoroutine(Init());
        img = GetComponent<Image>();
        img.type = Image.Type.Filled;
    }

    IEnumerator Init()
    {
        yield return new WaitForEndOfFrame();
        player = Game.GetInstance().EntityCollection.Actors.First(o => o is Player) as Player;
        if (player != null)
            player.Health.OnChange += Health_OnChange;
    }

    private void Health_OnChange(object sender, Assets.Scripts.Common.ValueChangeEvenArgs<float> e)
    {
        img.fillAmount = e.New;
    }

    public void OnDestroy()
    {
        player.Health.OnChange -= Health_OnChange;
    }
}