using DG.Tweening;
using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float timeToScale;
    protected Vector3 defaultScale;
    protected Tween tween;
    protected AudioSource source;

    protected AudioInteractor audioInteractor;

    public virtual void Initialize()
    {
        if(!TryGetComponent<AudioSource>(out source))
        {
            source = gameObject.AddComponent<AudioSource>();
        }
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        defaultScale = gameObject.transform.localScale;
        gameObject.transform.localScale = Vector3.zero;
    }

    public virtual void VisibleItem()
    {
        if (tween != null) { tween.Kill(); }

        audioInteractor.PlayOtherSound(source, "WhooshItemVisible", 0.4f, 1);
        tween = transform.DOScale(defaultScale, timeToScale);
    }

    public virtual void UnvisibleItem()
    {
        if (tween != null) { tween.Kill(); }

        tween = transform.DOScale(Vector3.zero, timeToScale).OnComplete(() =>
        {
            tween.Kill();
            Destroy(gameObject);
        });
    }
}
