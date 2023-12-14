using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRotateItemPanel : Panel
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private float speed;

    [SerializeField] private Toggle moveRotate;
    [SerializeField] private Toggle moveOnly;
    [SerializeField] private Toggle rotateOnly;

    private NotificationInteractor notificationInteractor;

    private JoystickScript joystickScript;
    public override void Initialize()
    {
        base.Initialize();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        moveRotate.onValueChanged.AddListener((value) =>
        {
            if (value)
            {
                if(itemSpawner._spawningObj == null)
                {
                    notificationInteractor.CreateNotification("Warning", "Not selected AR target");
                    return;
                }
                this.joystickScript = gameObject.AddComponent<MoveRotateItem>();
                joystickScript.SetData(itemSpawner, joystick, speed);
            }
            else
            {
                if (joystickScript == null)
                {
                    return;
                }
                Destroy(this.joystickScript);
            }
        });
        moveOnly.onValueChanged.AddListener((value) =>
        {
            if (value)
            {
                if (itemSpawner._spawningObj == null)
                {
                    notificationInteractor.CreateNotification("Warning", "Not selected AR target");
                    return;
                }
                this.joystickScript = gameObject.AddComponent<MoveItem>();
                joystickScript.SetData(itemSpawner, joystick, speed);
            }
            else
            {
                if (joystickScript == null)
                {
                    return;
                }
                Destroy(this.joystickScript);
            }
        });
        rotateOnly.onValueChanged.AddListener((value) =>
        {
            if (value)
            {
                if (itemSpawner._spawningObj == null)
                {
                    notificationInteractor.CreateNotification("Warning", "Not selected AR target");
                    return;
                }
                this.joystickScript = gameObject.AddComponent<RotateItem>();
                joystickScript.SetData(itemSpawner, joystick, speed);
            }
            else
            {
                if (joystickScript == null)
                {
                    return;
                }
                Destroy(this.joystickScript);
            }
        });
    }
    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        if (joystickScript != null)
        {
            joystickScript.RemoveData();
        }
    }
}
