using UnityEngine;

public abstract class BasePickableItem : MonoBehaviour
{
    public virtual void Collect()
    {
        OnCollect();
    }

    // Метод, который будет переопределен в дочерних классах
    protected abstract void OnCollect();
}