using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest4_1 : MonoBehaviour
{
    class Player
    {
        public enum Buff
        {
            None,
            Buff1,
            Buff2,
        }

        public Buff _buff;

        public void BuffCheck(Buff buff)
        {
            if (buff == Buff.Buff1) NoneBuff();
            else
            {
                if (buff == Buff.Buff1) Buff1();
                if (buff == Buff.Buff1) Buff2();
            }
        }

        public void Attack(Buff buff)
        {
            BuffCheck(buff);
            Debug.Log("Attack");
        }

        void NoneBuff() { }
        void Buff1() { Debug.Log("Buff1"); } //버프식 계산 함수1
        void Buff2() { Debug.Log("Buff2"); } //버프식 계산 함수1
    }

    private void Start()
    {
        Player player = new Player();
        player._buff = Player.Buff.Buff1;
        player.Attack(player._buff);
    }
}
