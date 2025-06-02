using UnityEngine;

public class Enemy_1_Animations : MonoBehaviour
{
    private static readonly int s_IsMoveDown = Animator.StringToHash("IsMoveDown");
    private static readonly int s_IsMoveUp = Animator.StringToHash("IsMoveUp");
    private static readonly int s_IsMoveSide = Animator.StringToHash("IsMoveSide");

    [SerializeField] private Animator _enemy_1_Animations;

    public void TriggerMoveDownAnimation()
    {
        _enemy_1_Animations.SetTrigger(s_IsMoveDown);
    }

    public void TriggerMoveUpAnimation()
    {
        _enemy_1_Animations.SetTrigger(s_IsMoveUp);
    }

    public void TriggerMoveSideAnimation()
    {
        _enemy_1_Animations.SetTrigger(s_IsMoveSide);
    }
}
