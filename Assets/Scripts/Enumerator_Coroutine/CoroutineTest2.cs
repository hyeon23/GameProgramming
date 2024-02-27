using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineTest2 : MonoBehaviour
{
    /*
     * Yield
     * YieldInstruction Ŭ���� : �ڷ�ƾ�� ���� �ð� ����ϰ�, �����ϴ� ������� �۵��ϴµ�
     * �ش� ����� ������ Ŭ������ YieldInstruction Ŭ����
     */

    float time;

    //���� Update ȣ�� �ñ��� ��� �� ����
    IEnumerator CoroutineTest()
    {

        //���� Update ȣ�� �ñ��� ��� �� ����
        yield return null;

        //���� FixedUpdate ȣ�� �ñ��� ��� �� ����
        yield return new WaitForFixedUpdate();

        //float time��ŭ �ð��� ���� �� ù �����ӱ��� ��� �� ����
        //Time.deltaTime�� ���������� ���ؼ� �����ϴ� �Ͱ� ������ �ڵ�
        //�̷� ���� ���� �߻�
        yield return new WaitForSeconds(time);
        while (time < 1.0f)
        { 
            yield return null;
            time += Time.deltaTime;
        }

        //float time��ŭ �ð��� ���� �� ù �����ӱ��� ��� �� ����
        //TimeScale�� ������ ���� ����
        yield return new WaitForSecondsRealtime(time);

        //��� ������ �۾��� �Ϸ�Ǵ� �������� ���������� ��� �� ����
        yield return new WaitForEndOfFrame();

        //�ش� ������ ���̵� ������ ��� �� ����[��]
        yield return new WaitUntil(() => time > 10);

        //�ش� ������ ���̶�� ���(������ ������ ��� �� ����)
        yield return new WaitWhile(() => time > 10);
    }

    int cnt = 0;

    private void Start()
    {
        StartCoroutine(WaitLoop());
        StartCoroutine(CoroutineTest());
    }

    private void Update()
    {
        if (cnt < 1000) ++cnt;
        Debug.Log(cnt);
    }

    IEnumerator WaitLoop()
    {
        //...
        yield return new WaitUntil(() => cnt == 1000);
        Debug.LogError("1000");
    }
}