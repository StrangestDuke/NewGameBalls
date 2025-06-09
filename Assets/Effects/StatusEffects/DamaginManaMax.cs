using UnityEngine;

[CreateAssetMenu(fileName = "damaginStatEffectMana", menuName = "statuses/damaginStatEffectMana")]
public class DamagingManaMax : statusEffect
{
    // Øàáëîí äëÿ ñòàòóñîâ Scriptable Object
    public string effectname = "testing rose";
    public Effect[] effects;
    public int buildUp;
    public int buildUpMax;
    public int Ammount;

    public override bool IsItTimeToGo(stats player, int time)
    {
       /* if (duration - time < 0)
        {
            RemoveEffect(player);
            return true;

        }
        else
        {
            duration = duration - time;
            return false;
        }*/
       return false;
    }
    public override void AddEffect(stats player)
    {
        player.takeMaxMana(Ammount *-1);
    }

    public override void RemoveEffect(stats player)
    {
        player.takeMaxMana(Ammount);
    }
}
