
namespace Chapter07
{ 
    public class Dummy
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Dummy(string n, int a)
        {
            Name = n;
            Age = a;
        }


        public override string ToString()
        {
            return "(" + Name + ", " + Age + ")";
        }
    }
}

