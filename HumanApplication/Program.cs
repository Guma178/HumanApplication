using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumansApp
{
    abstract class Human
    {
        public string FLP { get; set; }
        public DateTime Birthday { get; set; }
        protected Human(string FLP, DateTime Birthday)
        {
            this.FLP = FLP;
            this.Birthday = Birthday;
        }

        protected bool isMarried;
        protected List<Human> child = new List<Human>();
        protected virtual float GetAvgHeight() { return 1770f; }
        protected abstract string FamilyState { get; set; }
    }

    class Boy : Human
    {
        public Boy(string FLP, DateTime Birthday) : base(FLP, Birthday)
        { }

        public void AddChild(Human child)
        {
            base.child.Add(child);
            IsFather = true;
        }

        public Human GetChild(int n)
        {
            return child[n];
        }

        public bool IsFather { get; private set; }

        protected override float GetAvgHeight()
        { return 1810f; }
        protected override string FamilyState
        {
            get
            {
                if (base.isMarried)
                    return "Женат";
                else
                    return "Не женат";
            }
            set
            {
                if (value == "Женат")
                    base.isMarried = true;
                else if (value == "Не женат")
                    base.isMarried = false;
            }
        }
    }

    class Girl : Human
    {
        public Girl(string FLP, DateTime Birthday) : base(FLP, Birthday)
        { }

        public void AddChild(Human child)
        {
            base.child.Add(child);
            IsMother = true;
        }

        public bool IsMother
        {
            get;
            private set;
        }

        protected override float GetAvgHeight()
        { return 1730f; }
        protected override string FamilyState
        {
            get
            {
                if (base.isMarried)
                    return "Замужем";
                else
                    return "Не замужем";
            }
            set
            {
                if (value == "Замужем")
                    base.isMarried = true;
                else if (value == "Не замужем")
                    base.isMarried = false;
            }
        }
    }
    class Program
    {
        //comment
        static void Main(string[] args)
        {
            Boy b1 = new Boy("NLP1", DateTime.Now);
            b1.AddChild(new Boy("NLP2", DateTime.Now));
            Girl g2 = null;
            Boy b2 = null;
            if (b1.GetChild(0) is Girl)
                g2 = (Girl)b1.GetChild(0);
            else
                b2 = b1.GetChild(0) as Boy;
            if (b1.IsFather && b2 != null)
                Console.WriteLine(b1.FLP + " " + b2.FLP);
            Console.ReadKey();
        }
    }
}
