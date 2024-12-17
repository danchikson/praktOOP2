using System;

// Интерфейс для действий с инспекциями
interface IInspectionRequest
{
    void PublishRequest();
}

// Абстрактный класс для участников
abstract class Participant
{
    public string Name { get; private set; }

    protected Participant(string name)
    {
        Name = name;
    }

    public abstract void DisplayInfo();
}

// Класс Фермер
class Farmer : Participant, IInspectionRequest
{
    public Farmer(string name) : base(name) { }

    public void PublishRequest()
    {
        Console.WriteLine($"{Name}: Публикует запрос на инспекцию.");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Фермер: {Name}");
    }
}

// Класс Оператор дронов
class Operator : Participant
{
    public Operator(string name) : base(name) { }

    public void ReceiveRequest()
    {
        Console.WriteLine($"{Name}: Принимает запрос на инспекцию.");
    }

    public void BuildRoute(Drone drone)
    {
        Console.WriteLine($"{Name}: Строит маршрут для дрона.");
        drone.PerformInspection();
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Оператор: {Name}");
    }
}

// Класс Дрон
class Drone
{
    public void PerformInspection()
    {
        Console.WriteLine("Дрон: Выполняет инспекцию поля.");
    }

    public void SendData(Operator operatorInstance)
    {
        Console.WriteLine("Дрон: Данные инспекции получены.");
    }
}

// Класс Агроном
class Agronomist : Participant
{
    public Agronomist(string name) : base(name) { }

    public void AnalyzeData()
    {
        Console.WriteLine($"{Name}: Анализирует данные.");
    }

    public void SendAnalysis(Farmer farmer)
    {
        Console.WriteLine($"{Name}: Отправляет аналитику фермеру.");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Агроном: {Name}");
    }
}

// Главный класс для выполнения
class AgricultureInspection
{
    static void Main(string[] args)
    {
        Farmer farmer = new Farmer("Иван");
        Operator operatorInstance = new Operator("Алексей");
        Drone drone = new Drone();
        Agronomist agronomist = new Agronomist("Мария");

        // Процесс инспекции
        farmer.PublishRequest();
        operatorInstance.ReceiveRequest();
        operatorInstance.BuildRoute(drone);
        drone.SendData(operatorInstance);
        agronomist.AnalyzeData();
        agronomist.SendAnalysis(farmer);
        farmer.DisplayInfo();
        Console.WriteLine("Инспекция завершена, данные получены.");
    }
}
