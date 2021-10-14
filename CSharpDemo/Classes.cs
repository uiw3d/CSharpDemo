
namespace CSharpDemo
{
    class HealthComp
    {
        public delegate void OnDie();
        public delegate void OnHealthChange(float newValue);

        OnDie _onDie;
        public OnDie onDie
        {
            get { return _onDie; }
            set { _onDie = value; }
        }

        OnHealthChange _onHealthChange;
        public OnHealthChange onHealthChange
        {
            get { return _onHealthChange; }
            set { _onHealthChange = value; }
        }

        public HealthComp(float health)
        {
            this.health = health;
        }
        float health;
        public float Health
        {
            set 
            {
                health = value;
                onHealthChange.Invoke(health);
                if(health <= 0)
                {
                    onDie.Invoke();
                }
            }
            get { return health; }
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
        }
    }

    interface IObjectGenericInfo
    {
        float GetWeight();
        string GetName();
    }

    class Animal : IObjectGenericInfo
    {
        public float GetWeight() { return weight; }
        public string GetName() { return name; }
        //constructor
        public Animal()
        {
        }

        public Animal(string AnimalName, int AnimalAge, float AnimalWeight)
        {
            name = AnimalName;
            age = AnimalAge;
            weight = AnimalWeight;
            _healthComp = new HealthComp(10);
            _healthComp.onDie += Die;
            _healthComp.onHealthChange += HealthUpdated;
        }
        void HealthUpdated(float newHealth)
        {
            Orange.PrintObject($"{name} : my health is now: {newHealth}");
        }
        void Die()
        { 
            Orange.PrintObject($"{name} : Ah! I am dead");
        }

        HealthComp _healthComp;
        public HealthComp healthComp
        {
            get { return _healthComp; }
        }
        
        string name;
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        int age;
        public int Age
        {
            set { age = value; }
            get { return age; }
        }

        float weight;
        public float Weight
        {
            set {
                    weight = System.Math.Clamp(value, 0, float.MaxValue);
                }
            get {
                    return weight;
                }
        }

        public void SetName(string newName)
        {
            name = newName;
        }

        //prefer to use setter and getter instead of public variables
        public void SetAge(int newAge)
        {
            if(newAge < 0)
            {
                System.Exception newException = new System.Exception("age is smaller than 0");
                throw newException;
            }
            newAge = System.Math.Clamp(newAge, 0, int.MaxValue);
            age = newAge;
        }
        public int GetAge() { return age; }

        public virtual string toString()
        {
            return $"{name} is {age} years old, weight {weight}";
        }
    }

    class Dog : Animal
    { 
        public Dog() {}
        public Dog(string AnimalName, int AnimalAge, float AnimalWeight, string favorateTreat)
            : base(AnimalName, AnimalAge, AnimalWeight)
        {
            this.favorateTreat = favorateTreat;
        }
        string favorateTreat;
        public override string toString()
        {
            return $"{Name} is a Dog, {Age} years old, weight: {Weight}, likes to eat: {favorateTreat}";
        }
    }

    class Bird : Animal
    {
        public Bird() { }
        public Bird(string AnimalName, int AnimalAge, float AnimalWeight, float flyHeight)
            : base(AnimalName, AnimalAge, AnimalWeight)
        {
            this.flyHeight = flyHeight;
        }
        float flyHeight;
        public override string toString()
        {
            return $"{Name} is a Bird, {Age} years old, weight: {Weight}, flies {flyHeight} hight";
        }
    }

    class Car : IObjectGenericInfo
    {
        public float GetWeight() { return weight; }
        public string GetName() { return $"{year} {make} {model}"; }
        public Car() { }
        public Car(float weight, string make, string model, int year)
        {
            this.weight = weight;
            this.make = make;
            this.model = model;
            this.year = year;
            _healthComp = new HealthComp(10);
            _healthComp.onDie += Die;
            _healthComp.onHealthChange += HealthUpdated;
        }

        void HealthUpdated(float newHealth)
        {
            Orange.PrintObject($"{GetName()} : my health is now: {newHealth}");
        }
        void Die()
        {
            Orange.PrintObject($"{GetName()} blews up!");
        }


        HealthComp _healthComp;
        public HealthComp healthComp
        {
            get { return _healthComp; }
        }

        string make;
        string model;
        int year;
        float weight;
        public float Weight
        {
            set { weight = value; }
            get { return weight; }
        }
    }

    //public member is dangerous, fragile
    class Date
    {
        int year;
        int month;
        int day;

        public void IncrementDate(int daysToIncrement)
        {
            
        }
    }
}

