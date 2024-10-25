import java.util.ArrayList;
import java.util.List;

// Інтерфейс для дій з інспекціями
interface InspectionRequest {
    void publishRequest();
}

// Абстрактний клас для учасників
abstract class Participant {
    private String name;

    public Participant(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public abstract void displayInfo();
}

// Клас Фермер
class Farmer extends Participant implements InspectionRequest {
    public Farmer(String name) {
        super(name);
    }

    @Override
    public void publishRequest() {
        System.out.println(getName() + ": Публікує запит на інспекцію.");
    }

    @Override
    public void displayInfo() {
        System.out.println("Фермер: " + getName());
    }
}

// Клас Оператор дронів
class Operator extends Participant {
    public Operator(String name) {
        super(name);
    }

    public void receiveRequest() {
        System.out.println(getName() + ": Приймає запит на інспекцію.");
    }

    public void buildRoute(Drone drone) {
        System.out.println(getName() + ": Будує маршрут для дрона.");
        drone.performInspection();
    }

    @Override
    public void displayInfo() {
        System.out.println("Оператор: " + getName());
    }
}

// Клас Дрон
class Drone {
    public void performInspection() {
        System.out.println("Дрон: Виконує інспекцію поля.");
    }

    public void sendData(Operator operator) {
        System.out.println("Дрон: Дані інспекції отримано.");
    }
}

// Клас Агроном
class Agronomist extends Participant {
    public Agronomist(String name) {
        super(name);
    }

    public void analyzeData() {
        System.out.println(getName() + ": Аналізує дані.");
    }

    public void sendAnalysis(Farmer farmer) {
        System.out.println(getName() + ": Відправляє аналітику фермеру.");
    }

    @Override
    public void displayInfo() {
        System.out.println("Агроном: " + getName());
    }
}

// Головний клас для виконання
public class AgricultureInspection {
    public static void main(String[] args) {
        Farmer farmer = new Farmer("Іван");
        Operator operator = new Operator("Олексій");
        Drone drone = new Drone();
        Agronomist agronomist = new Agronomist("Марія");

        // Процес інспекції
        farmer.publishRequest();
        operator.receiveRequest();
        operator.buildRoute(drone);
        drone.sendData(operator);
        agronomist.analyzeData();
        agronomist.sendAnalysis(farmer);
        farmer.displayInfo();
        System.out.println("Інспекція завершена, дані отримано.");
    }
}
