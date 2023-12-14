using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObject : MonoBehaviour
{
    private GameObject selectedObject; //��������� ������ ��� ������� �������� � ������� ������

    public void ChangeARObject(GameObject chooseObject) //�������� ������
    {
        if(selectedObject != null) //��������� ���� �� ��� ��������� ������
        {
            if(selectedObject == chooseObject) //��������� ����� �� ������� ������ ����������
            {
                return;
            }

            selectedObject.SetActive(false);
        }

        selectedObject = chooseObject;//�������� �������� ������� ������, ������� ��� ������
        selectedObject.SetActive(true);//�������� ���
    }

    public void ChangeMaterial(Material material)//����� ���������
    {
        selectedObject.GetComponent<Renderer>().material = material;//������ �������� �������� �������
    }
}
