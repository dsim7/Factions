
using UnityEngine.Events;

public abstract class Effect
{
    public abstract void Execute();
}

public class Effect<T> : Effect
{
    public T target { get; set; }
    public UnityAction<T> action { get; set; }

    public override void Execute()
    {
        action(target);
    }
}
