using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DelegateTest4_2 : MonoBehaviour
{
    class Player
    {
        private delegate void BuffDelegate();
        private BuffDelegate _buffDelegate;
        public enum Buff
        {
            None,
            Buff1,
            Buff2,
        }
        private Buff _buff;
        //���� �ɸ� ������ ���� �ڵ����� ȣ�� �Լ��� �����ϱ� ���� ������Ƽ �� ��������Ʈ ���� ��ġ
        public Buff _Buff {
            get { return _buff; }
            set
            {
                if (_buff == value) return;

                _buff = value;
                if (_buff == Buff.Buff1) _buffDelegate = Buff1;
                else if (_buff == Buff.Buff2) _buffDelegate = Buff2;
                else if (_buff == Buff.None) _buffDelegate = NoneBuff;
            }
        }
        public void Attack()
        {
            _buffDelegate();//�Ǵ� _buffDelegate.Invoke();
            Debug.Log("Attack");
        }
        void NoneBuff() { }
        void Buff1() { Debug.Log("Buff1"); } //������ ��� �Լ�1
        void Buff2() { Debug.Log("Buff2"); } //������ ��� �Լ�1
    }
    private void Start()
    {
        Player player = new Player();
        player._Buff = Player.Buff.Buff1;
        player.Attack();
    }
}
