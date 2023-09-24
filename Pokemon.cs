﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QB_Lab
{
    public class Pokemon : IClassModel
    {
        public int Id { get; set; }
        public int DexNumber { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }

        public Pokemon()
        {
            this.Id = Id;
            this.DexNumber = DexNumber;
            this.Name = Name;
            this.Form = Form;
            this.Type1 = Type1;
            this.Type2 = Type2;
            this.Total = Total;
            this.HP = HP;
            this.Attack = Attack;
            this.Defense = Defense;
            this.SpecialAttack = SpecialAttack;
            this.SpecialDefense = SpecialDefense;
            this.Speed = Speed;
            this.Generation = Generation;
        }
    }

    
}
