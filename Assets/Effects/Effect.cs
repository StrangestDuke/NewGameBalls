using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract void ExecuteEffect(stats actor);

    public abstract void ReverseEffect(stats actor);
}
