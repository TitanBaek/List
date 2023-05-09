using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public enum Job { 무직, 회사원, 군인, 학생, 등산애호가 };
    public class Player
    {
        public string name;
        public Job job;
        public Position pos;
        public Dictionary<EquipType, Equip> playerEquip;
        public Inventory inventory;
        private int level;
        public int Level { get { return this.level; } }
        private int exp;
        public int Exp { get { return this.exp; } }
        private float exp_cal;
        public int Exp_cal { get { return (this.level * 100) * (int)this.exp_cal; } }
        private int hp;
        public int Hp { get { return this.hp; } }
        private int max_hp;
        public int Max_hp { get {  return this.max_hp; } }
        private int sp;
        public int Sp { get { return this.sp; } }
        private int max_sp;
        public int Max_sp { get { return this.max_sp; } }
        private int ap;
        public int Ap { get { return this.ap; } }
        private int dp;
        public int Dp { get { return this.dp; } }
        private int luck;
        public int Luck { get { return this.luck; } }

        public Player(string name,Job job)
        {
            this.name = name;
            this.job = job;
            this.playerEquip = new Dictionary<EquipType, Equip>();
            this.inventory = new Inventory(this);
            this.level = 1;
            this.exp = 0;
            this.exp_cal = 0.3f;
            this.hp = 100;
            this.max_hp = 100;
            this.sp = 50;
            this.max_sp = 50;
            this.ap = 5;
            this.dp = 5;
            this.luck = 20;
            
            switch(job)
            {
                case Job.학생: this.hp = 90; this.max_hp = 90; this.sp = 60; this.max_sp = 60; this.ap = 4; this.dp = 4; break;
                case Job.회사원: this.hp = 110; this.max_hp = 110; this.sp = 40; this.max_sp = 40; this.dp = 8; break;
                case Job.군인: this.hp = 150; this.max_hp = 15; this.sp = 70; this.max_sp = 70; this.ap = 10; this.dp = 5; break;
                case Job.등산애호가: this.hp = 100; this.max_hp = 100; this.sp = 100; this.max_sp = 100; this.ap = 1; this.dp = 5; break;
            }
        }


        /// <summary>
        /// 레벨업
        /// </summary>
        public void LevelUp()
        {
            this.level++;
            this.exp_cal += 0.1f;
            int plus_hp = 0;
            int plus_sp = 0;
            int plus_luck = 0;

            if(this.job == Job.회사원)                    // 회사원
            {
                plus_hp += 10;
                plus_sp += 2;
                plus_luck += 5;
            }else if(this.job == Job.군인)                // 군인
            {
                plus_hp += 15;
                plus_sp += 3;
                plus_luck += 2;
            }
            else if(this.job == Job.등산애호가)           // 등산애호가 
            {
                plus_hp += 5;
                plus_sp += 5;
                plus_luck += 10;
            }
            else if(this.job == Job.학생)                // 학생
            {
                plus_hp += 5;
                plus_sp += 7;
                plus_luck += 8;
            }
            else                                         // 무직
            {
                plus_hp += 7;
                plus_sp += 7;
                plus_luck += 5;
            }

            this.max_hp += plus_hp;
            this.max_sp += plus_sp;
            this.luck += plus_luck;
            Console.WriteLine($"{this.name}({this.job})의 레벨이 올랐다!");
            Thread.Sleep(1000);
            Console.WriteLine($"최대 체력 증가 : +{plus_hp}");
            Thread.Sleep(200);
            Console.WriteLine($"최대 행동력 증가 : +{plus_sp}");
            Thread.Sleep(200);
            Console.WriteLine($"행운 증가 : +{plus_luck}");

        }

        public void TryMove(Direction dir)
        {
            Position prevPos = pos;

            // 위,아래,좌,우에 이동가능한 스테이지가 있는지 확인하고
            // 이동 가능한 방향만 출력하여 선택지를 입력하는 화면을 호출
            switch (dir)
            {
                case Direction.Up:
                    pos.y--; break;
                case Direction.Down:
                    pos.y++; break;
                case Direction.Left:
                    pos.x--; break;
                case Direction.Right:
                    pos.x++; break;
            }

            if (Data.stages[pos.y,pos.x] != null)
            {
                // 스테이지 이동 구현
            } else
            {
                // 이동 불가 Text 출력
                pos = prevPos;
            }
        }

        /// <summary>
        /// 경험치를 증감시키고 레벨업 여부를 확인
        /// </summary>
        public void CalculExp(int exp)
        {
            this.exp += exp;
            if(this.exp >= (this.level * 100) * this.exp_cal)
            {
                this.exp = (int)(this.level * 100 * this.exp_cal) - this.exp;
                LevelUp();
            }
        }

        public void UseingItem(string mode, int point)
        {
            StringBuilder sb = new StringBuilder();
            if(mode == "hp")
            {
                sb.Append("체력이");
                this.hp += point;
                CalculHp();
            }else if(mode == "sp")
            {
                sb.Append("행동력이");
                this.sp += point;
                CalculSp();
            }
            sb.AppendLine($"{point} 만큼 올랐다!");
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 적에게 공격받음
        /// </summary>
        public void TakeDamege(int dmg)
        {
            dmg -= GetTotalDefence();

            if(dmg <= 0)
            {
                dmg = 0;
                Console.WriteLine($"{this.name}은(는) 끄떡 없었다!");
                return;
            }

            Console.WriteLine($"{this.name}은(는) {dmg}의 대미지를 입었다!");
            this.hp -= dmg;
        }

        /// <summary>
        /// 배틀에 사용되는 주사위 굴리기
        /// </summary>
        /// <returns></returns>
        public int RollDice()
        {
            int randomSeed = (int)DateTime.Now.Ticks;

            Random rand = new Random(randomSeed);
            int diceNumber = rand.Next(0 + (int) this.luck / 2 , 50 + this.luck); ;

            return diceNumber;
        }

        /// <summary>
        /// 적을 공격
        /// </summary>
        public void AttackEnemy(Monster monster)
        {
            int dmg = this.ap;
            // 장비를 착용하고 있는 경우
            if (this.playerEquip.ContainsKey(EquipType.손))
            {
                dmg += this.playerEquip[EquipType.손].GetDamage();
            }
            Console.WriteLine($"{this.name}의 공격!");
            monster.TakeDamege(dmg, this);
        }

        public int GetTotalDefence()
        {
            // 장비중인 아이템의 DP(방어력)를 모두 가져와서 리턴함
            int ammorDp = 0;
            foreach(KeyValuePair<EquipType,Equip> i in this.playerEquip)
            {
                ammorDp += i.Value.GetDefence();
            }
            return ammorDp;
        }

        /// <summary>
        /// SP 회복을 위한 휴식
        /// </summary>
        public void GetRest(int restTime)
        {
            this.sp += (int) restTime / 1000;
            CalculSp();
        }

        public void CalculSp()
        {
            if(this.sp >= this.max_sp)
            {
                this.sp = this.max_sp;
            }
        }
        public void CalculHp()
        {
            if(this.hp >= this.max_hp)
            {
                this.hp = this.max_hp;
            }
        }

    }
}
