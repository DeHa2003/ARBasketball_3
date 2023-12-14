using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObject : MonoBehaviour
{
    private GameObject selectedObject; //Выбранный объект над которым работаем в текущий момент

    public void ChangeARObject(GameObject chooseObject) //Выбираем объект
    {
        if(selectedObject != null) //Проверяем есть ли уже выбранный объект
        {
            if(selectedObject == chooseObject) //Проверяем равен ли текущий объект выбранному
            {
                return;
            }

            selectedObject.SetActive(false);
        }

        selectedObject = chooseObject;//Присваем текущему объекту объект, который был выбран
        selectedObject.SetActive(true);//Включаем его
    }

    public void ChangeMaterial(Material material)//Выбор материала
    {
        selectedObject.GetComponent<Renderer>().material = material;//Меняем материал текущему объекту
    }
}
