using UnityEngine;

public class Logic<T> : ILogic
    where T : LogicData
{
    protected T logicData { get; private set; }

    public void Initialize(LogicData initData)
    {
        if (initData is T correctLogic)
            logicData = correctLogic;
        else
            Debug.LogError($"Incorrect data type for {GetType()}");
    }
}
