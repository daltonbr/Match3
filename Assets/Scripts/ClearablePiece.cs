using UnityEngine;
using System.Collections;

public class ClearablePiece : MonoBehaviour
{
    public AnimationClip clearAnimation;

    private bool _isBeingCleared = false;

    public bool IsBeingCleared => _isBeingCleared;

    protected GamePiece piece;

    private void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    public virtual void Clear()
    {
        piece.GridRef.level.OnPieceCleared(piece);
        _isBeingCleared = true;
        StartCoroutine(ClearCoroutine());
    }

    private IEnumerator ClearCoroutine()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(clearAnimation.name);

            yield return new WaitForSeconds(clearAnimation.length);

            Destroy(gameObject);
        }
    }
}
