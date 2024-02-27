 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTest : MonoBehaviour
{
    public interface IOnDamaged{
        public void OnDamaged();
    }

    public class Player
    {
        public void Attack(IOnDamaged mob)
        {
            mob.OnDamaged();
        }
    }

    public class Monster
    {
        int HP;
        int MP;
        int ATK;
        int DEF;

        public virtual void Idle()
        {
            Debug.Log("Idle");
        }

        public virtual void Move()
        {
            Debug.Log("Move");
        }

        public virtual void Attack()
        {
            Debug.Log("Attack");
        }
    }

    public class NPC : IOnDamaged
    {
        int HP;
        int DEF;

        public void OnDamaged()
        {
            Debug.Log("NPC OnDamaged");
        }
    }

    public class Orc : Monster, IOnDamaged
    {
        public override void Idle()
        {
            Debug.Log("Orc Idle");
        }
        public override void Move()
        {
            Debug.Log("Orc Move");
        }
        public override void Attack()
        {
            Debug.Log("Orc Attack");
        }

        public void OnDamaged()
        {
            Debug.Log("Orc OnDamaged");
        }
    }

    public class Elf : Monster, IOnDamaged
    {
        public override void Idle()
        {
            Debug.Log("Elf Idle");
        }
        public override void Move()
        {
            Debug.Log("Elf Move");
        }
        public override void Attack()
        {
            Debug.Log("Elf Attack");
        }
        public void OnDamaged()
        {
            Debug.Log("Elf OnDamaged");
        }
    }

    public class Goblin : Monster, IOnDamaged
    {
        public override void Idle()
        {
            Debug.Log("Goblin Idle");
        }
        public override void Move()
        {
            Debug.Log("Goblin Move");
        }
        public override void Attack()
        {
            Debug.Log("Goblin Attack");
        }

        public void OnDamaged()
        {
            Debug.Log("Goblin OnDamaged");
        }
    }

    private void Start()
    {
        Orc orc = new Orc();
        Elf elf= new Elf();
        Goblin goblin = new Goblin();
        NPC npc = new NPC();
        Player player = new Player();

        player.Attack(elf);
        player.Attack(orc);
        player.Attack(goblin);
        player.Attack(npc);
    }
}
