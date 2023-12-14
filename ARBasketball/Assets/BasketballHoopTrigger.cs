using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasketballHoopTrigger : MonoBehaviour
{
    public UnityEvent OnGoal;
    [SerializeField] private AudioSource source;
    [SerializeField] private int scoreCount;
    [SerializeField] private int bankCount;

    private AudioInteractor audioInteractor;
    private ScoreInteractor scoreInteractor;
    private BankInteractor bankInteractor;
    private void Start()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        bankInteractor = Game.GetInteractor<BankInteractor>();
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnGoal?.Invoke();
        bankInteractor.AddCoins(this.name, bankCount);
        scoreInteractor.AddScore(this.name, scoreCount);
        audioInteractor.PlayOtherSound(source, "Setka", Random.Range(0.7f, 1f), 1);
    }
}
