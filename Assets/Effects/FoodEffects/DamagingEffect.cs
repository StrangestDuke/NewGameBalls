using UnityEngine;

[CreateAssetMenu(fileName = "harmCrit", menuName = "items/harmCrit")]
public class DamagingEffect : Effect
{

    public int Ammount;

    public override void ExecuteEffect(stats player)
    {
        player.CurrentCrit -= Ammount;
    }
    public override void ReverseEffect(stats player)
    {
        player.CurrentCrit += Ammount;
    }
}
