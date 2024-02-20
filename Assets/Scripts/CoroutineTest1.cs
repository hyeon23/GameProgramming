using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTest1 : MonoBehaviour
{
    /*
     * �ڷ�ƾ: ������Ʈ �޼���� �޸� 
     * �޼����� ������� ����Ƽ�� ��ȯ�ϰ�, 
     * Ư�� ������ �Ǹ� �ٽ� �����ϴ� ���
     */

    //Fade In & Out Coroutine
    public Image image;
    private float alpha;
    private float fadeTime = 3.0f;
    private void Start()
    {
        Coroutine co1 = StartCoroutine(FadeIn());//IEnumerator ��ȯ Ÿ�� / ������ �� ��� ���
        Coroutine co2 = StartCoroutine("FadeIn");//����õ : ��� X(���� �ִ� 1���ۿ� ���� �Ұ�)
        //string -> Coroutine���� ��ȯ�ϹǷ�, ���� bad

        StopCoroutine(co1);//������ �� ��� ���
        StopCoroutine(FadeIn());
        StopCoroutine("FadeIn");
        StopAllCoroutines();//�ش� ��ũ��Ʈ�� ��� �ڷ�ƾ ����
    }
    IEnumerator FadeIn()
    {
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime / fadeTime;
            image.color = new Color(1,1,1,alpha);
            yield return null;

            if (alpha > 0.5f) yield break;
        }
    }

    /*
     * �ڷ�ƾ ��� ����
     * 1. MonoBehaviour ��� �ʼ�
     * 2. IEnumerator�� ��ȯ�ϴ� �Լ�
     * 3. StartCoroutine(IEnumerator)�� ���
     * 4. yield return(����)�� ����Ѵ�.
     * yield return�� ������ ����, ���� �ٺ��� ����Ǵ� �������� �ٸ�
     * 5. �ڷ�ƾ�� �����ϴ� ���ӿ�����Ʈ�� ��Ȱ��ȭ�ǰų� �ı��Ǹ� �ڷ�ƾ ����
     */

    /*
     * yield break: �ڷ�ƾ ����
     */

    IEnumerator Count()
    {
        //������1
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        //������� �ѱ� = ���

        //���� ���� �޼� �� �簳
        //������2
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        //������� �ѱ� = ���

        gameObject.SetActive(false);
        //Destroy(gameObject);

        //���� ���� �޼� �� �簳
        //������3
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        //������� �ѱ� = ���

        //���� ���� �޼� �� �簳
        //������4
    }

    /*
     * �ڷ�ƾ ��� ���
     * StartCoroutine() : �ڷ�ƾ ���� �޼ҵ�
     */

    /*
     * �ڷ�ƾ ���� ���
     * StopCoroutine() : �ڷ�ƾ ���� �޼ҵ�
     * StopAllCoroution() : �ش� ��ũ��Ʈ�� ��� �ڷ�ƾ ����
     */

    /*
     * �ڷ�ƾ �۵� ���
     * �⺻���� Enumerator�� �迭�� �÷����� ����, ��ȸ�� ���� �����̶� �� �����ӿ� ������ ����
     * Unity �ڷ�ƾ�� ���� Enumerator�� ����, ��ȸ�ϸ�, ���� �����ӿ� ������ ����
     */
}