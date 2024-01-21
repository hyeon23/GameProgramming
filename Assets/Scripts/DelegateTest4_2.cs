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
        //현재 걸린 버프에 따라 자동으로 호출 함수를 수정하기 위한 프로퍼티 내 델리게이트 수정 조치
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
            _buffDelegate();//또는 _buffDelegate.Invoke();
            Debug.Log("Attack");
        }
        void NoneBuff() { }
        void Buff1() { Debug.Log("Buff1"); } //버프식 계산 함수1
        void Buff2() { Debug.Log("Buff2"); } //버프식 계산 함수1
    }
    private void Start()
    {
        Player player = new Player();
        player._Buff = Player.Buff.Buff1;
        player.Attack();
    }
}
