using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    //Lerp
    //Lerp �Լ��� ���� ������ ���
    //���� ����: �� ��(������/����) ������ ����(������ ���� ��)�� �����ϱ� ���� ���� �Ÿ��� ���� ��������� ����ϴ� ���
    //* ������ ���� �߰����� �����ϴ� ����̶� ���� �ȴ�.
    //���� ���Ǳ� �Ѵ�.

    //1, Mathf.Lerp(�ּҰ�, �ִ밪, ����(0 to 1))
    //������ ���� �ּҰ� - �ִ밪 ������ ������ �ش��ϴ� ���� ����Ǿ� ���´�.
    //�̵�, ȭ����ȯ, ����ȯ �� ���� ��ȯ�� ���

    Vector3 startPos;
    Vector3 targetPos = new Vector3(0, 5, 0);
    float currentTime = 0;
    public float targetTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector3.Lerp(startPos, targetPos, currentTime / targetTime);
    }

    //�پ��� Lerp �Լ���
    //1. Mathf.Lerp: �� �� ���� ����
    //2. Color.Lerp: �� Color ���� ����
    //3. Color32.Lerp: �� Color32 ���� ����
    //4. Vector2.Lerp: �� Vector2 ���� ����
    //5. Vector3.Lerp: �� Vector3 ���� ����
    //6. Vector4.Lerp: �� Vector4 ���� ����
    //7. Material.Lerp: �� Material ���� ����
}
