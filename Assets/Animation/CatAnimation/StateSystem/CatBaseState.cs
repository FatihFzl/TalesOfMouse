using UnityEngine;

public abstract class CatBaseState
{
    public abstract void EnterState(CatStateManager Cat);
    public abstract void UpdateState(CatStateManager Cat);
    public abstract void ExitState(CatStateManager Cat);
}
