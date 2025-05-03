using UnityEngine;

public abstract class BasePickableItem : MonoBehaviour
{
    public virtual void Collect()
    {
        OnCollect();
        Destroy(gameObject); // Уничтожаем объект после подбора
    }

    // Метод, который будет переопределен в дочерних классах
    protected abstract void OnCollect();
}