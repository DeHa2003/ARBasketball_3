using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMovement : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform transformFrom;
    [SerializeField] private Vector3 offset;
    [SerializeField] private AudioSource audioSource;

    private Item item;
    private Rigidbody rigid;

    private AudioInteractor audioInteractor;

    public void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
    }

    public void MoveItem(Item item)
    {
        this.item = item;
        rigid = this.item.GetComponent<Rigidbody>();
        rigid.isKinematic = false;
        rigid.AddForce(slider.value * Time.deltaTime * (transformFrom.forward + offset));

        audioInteractor.PlayOtherSound(audioSource, "WhooshSlider", slider.value / 15000);
    }
}
