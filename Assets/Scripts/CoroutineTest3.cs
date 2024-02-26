using System.Collections;
using UnityEngine;

public class CoroutineTest3 : MonoBehaviour
{
    //Start �Լ��� Coroutine���� �����ϴ� ������ ���� ����
    //������Ʈ�� �Ը� Ŀ����, ��ũ��Ʈ�� ���� Start�� ���� �����ϴ� ���� �ʿ�
    //�׷� ��� ���

    //ĳ��
    WaitForFixedUpdate wf = new WaitForFixedUpdate();

    IEnumerator Start()
    {
        yield return null;

        yield return Util.WaitForSecond(1.0f);
        yield return Util.WaitForSecond(1.1f);
        yield return Util.WaitForSecond(1.2f);
        yield return Util.WaitForSecond(1.3f);
    }

    //Unity �����Լ��� yield return�� ���� ���� ȣ���� ����
    //������Ģ - OnCollision �ø���
    IEnumerator OnCollisionEnter()
    {
        yield return wf;//ĳ��
    }
    //�Է�
    IEnumerator OnMouseEnter()
    {
        yield return wf;//ĳ��
    }
    //������
    private IEnumerator OnBecameInvisible()
    {
        yield return wf;//ĳ��
    }
    IEnumerator CoTest()
    {
        yield return wf;//ĳ��
    }
    //Coroutine ���� �ø���(StartCoroutine()) Garbage�� ����Ƿ�, �� �ʿ��� ��쿡�� ����ϴ� ���� ����
    //Ư�� �ڷ�ƾ�� �ݺ������� ����� �ʿ䰡 ���� ��
    //Update������ ��ü(Update�� Garbage ���� X)

    //yield return new �� ����ø��� Garbage�� �����ȴ�.

    //���� ���Ǵ� YieldInstructor���� ������ ����(ĳ���� ���� ��Ȱ��)

    //���ŷο� ĳ���� �ذ��ϴ� ���
    //WaitForSeconds wf0.1 = new WaitForSeconds(0.1f);
    //WaitForSeconds wf0.2 = new WaitForSeconds(0.2f);
    //WaitForSeconds wf0.3 = new WaitForSeconds(0.3f);
    //WaitForSeconds wf0.4 = new WaitForSeconds(0.4f);
    //WaitForSeconds wf0.5 = new WaitForSeconds(0.5f);

    //�ǰ��Ѵ�.
    //...
    //�̷��� ĳ�� �ؾ� �ϳ�...
    //�ƴϴ� => ���� Util Ŭ������ ����
    //���������� ����� ���

    //Util.cs ���Ͽ� �ſ� ȿ�����̰� ���������� ����ϴ� ���� �Լ��� �ۼ�

    //Utils.cs ������ ��� ȿ������ �۾��� ���� �����ڵ��� ���� �������� ���
}