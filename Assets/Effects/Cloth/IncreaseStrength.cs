using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseStrenght", menuName = "items/IncreaseStrenght")]
public class IncreaseStrenght : Effect
{
    public int Ammount;
    public override void ExecuteEffect(stats player)
    {
        player.strengthCurrent += Ammount;
    }

    public override void ReverseEffect(stats player)
    {
        player.strengthCurrent -= Ammount;
    }
}
