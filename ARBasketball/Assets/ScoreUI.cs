using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMaxScore;
    [SerializeField] private TextMeshProUGUI textScore;

    private AudioInteractor audioInteractor;
    private ScoreInteractor scoreInteractor;
    private NotificationInteractor notificationInteractor;
    public void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();

        scoreInteractor.OnChangedMaxScore += GetMaxScore;
        scoreInteractor.OnChangedScore += GetScore;
        scoreInteractor.OnChangedMaxScore += NewRecord;

        GetMaxScore();
        GetScore();
    }
    private void OnDestroy()
    {
        scoreInteractor.OnChangedMaxScore -= GetMaxScore;
        scoreInteractor.OnChangedScore -= GetScore;
    }
    private void GetScore()
    {
        textScore.text = scoreInteractor.score.ToString();
    }

    private void NewRecord()
    {
        audioInteractor.PlayEffectSound("Congratulate");
        notificationInteractor.CreateNotification("Message", "A new record has been broken. Congratulation!!!");
        scoreInteractor.OnChangedMaxScore -= NewRecord;
    }

    private void GetMaxScore()
    {
        textMaxScore.text = scoreInteractor.maxScore.ToString();
    }
}
