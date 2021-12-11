using UnityEngine.Events;

public static class SetTargetInvent
{
    private static UnityEvent<DirectMovementProvider> _onCombinationCreate;


    public static void AddListener(UnityAction<DirectMovementProvider> listener)
    {
        _onCombinationCreate.AddListener(listener);
    }

    public static void Invoke(DirectMovementProvider sender)
    {
        _onCombinationCreate.Invoke(sender);
    }
}