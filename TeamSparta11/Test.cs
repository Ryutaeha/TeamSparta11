using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Test
{
    internal class Player
    {
        public string name { get; set; }
        public string jobClass { get; set; }
        public Player() { }


        public Player(string name, string jobClass)
        {
            this.name = name;
            this.jobClass = jobClass;
        }

        public Player(Player saveData)
        {
            name = saveData.name;
            jobClass = saveData.jobClass;
        }

    }
}

