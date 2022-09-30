using System;
using System.Reflection;


    class Program
    {
        static void Main(string[] args)
        {
        Person tom = new Person("12345", "Tom");
        Type myType = typeof(Person);
        Console.WriteLine("Members:");
        foreach (MemberInfo member in myType.GetMembers())
        {
            Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
        }
        Console.WriteLine("Methods:");
        foreach (MethodInfo method in myType.GetMethods())
        {
            string modificator = "";

            // если метод статический
            if (method.IsStatic) modificator += "static ";
            // если метод виртуальный
            if (method.IsVirtual) modificator += "virtual ";

            Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
        }
        Console.WriteLine("Constructors:");
        foreach (ConstructorInfo ctor in myType.GetConstructors(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            string modificator = "";

            // получаем модификатор доступа
            if (ctor.IsPublic)
                modificator += "public";
            else if (ctor.IsPrivate)
                modificator += "private";
            else if (ctor.IsAssembly)
                modificator += "internal";
            else if (ctor.IsFamily)
                modificator += "protected";
            else if (ctor.IsFamilyAndAssembly)
                modificator += "private protected";
            else if (ctor.IsFamilyOrAssembly)
                modificator += "protected internal";

            Console.Write($"{modificator} {myType.Name}(");
            // получаем параметры конструктора
            ParameterInfo[] parameters = ctor.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                Console.Write($"{param.ParameterType.Name} {param.Name}");
                if (i < parameters.Length - 1) Console.Write(", ");
            }
            Console.WriteLine(")");
        }

        Console.WriteLine("Fields:");
        foreach (FieldInfo field in myType.GetFields(
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
        {
            string modificator = "";

            // получаем модификатор доступа
            if (field.IsPublic)
                modificator += "public ";
            else if (field.IsPrivate)
                modificator += "private ";
            else if (field.IsAssembly)
                modificator += "internal ";
            else if (field.IsFamily)
                modificator += "protected ";
            else if (field.IsFamilyAndAssembly)
                modificator += "private protected ";
            else if (field.IsFamilyOrAssembly)
                modificator += "protected internal ";

            // если поле статическое
            if (field.IsStatic) modificator += "static ";

            Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
        }

    }

    public enum Gender
    {
        Male,
        Female
    }

    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Person
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public DateTime Registered { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string[] Tags { get; set; }
        public Friend[] Friends { get; set; }


        public Person(string id, string name) { 
            Id = id;
            Name = name;
        }

        public void Print() {
            Console.WriteLine(Name, Id, Address, Gender);
        }
    }
}
