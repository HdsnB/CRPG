using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public class Monster:LivingCreature
    {
        public int ID;
        public string Name;
        public int MaximumDamage;
        public int RewardExperiencePoints;
        public int RewardGold;
        public List<LootItem> LootTable;

//Constructor
        public Monster(int iD, string name, int maximumDamage, int rewardExperiencePoints, int rewardGold,
            int currentHitPoints, int maximumHitPoints):base(currentHitPoints, maximumHitPoints)
        {
            ID = iD;
            Name = name;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();

        }
    }


}
