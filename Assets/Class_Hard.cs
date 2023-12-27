using System.Collections;
using System.Collections.Generic;
using kdh;
using UnityEngine;

namespace kdh
{
    class Orc
    {
        public int damage;
        public int defence = 10;
    }
}
public class Class_Hard : MonoBehaviour
{
    // Start is called before the first frame update

    //클래스 = 참조타입 -> new를 통해 동적 할당
    void Start()
    {
        kdh.Orc orc1 = new kdh.Orc();
        kdh.Orc orc2 = new kdh.Orc();

        
        orc1.damage = 5;
        //orc1 damage = 5
        //orc1 defence = 10


        orc2.damage = 10;
        //orc2 damage = 10
        //orc1 defence = 10

        orc1 = orc2;//orc1이 orc2를 가르킴
        
        orc1.defence = 20;

        //missing link ?
        //damage 5
        //defence = 10;

        //orc1 damage = 10
        //orc1 defence = 20

        //orc2 damage = 10
        //orc1 defence = 20
    }
    int gold;
    string movie;
}

