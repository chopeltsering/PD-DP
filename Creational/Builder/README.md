
# 🏗️ Builder Design Pattern

## 📖 Summary

The **Builder Design Pattern** is a **creational pattern** used to construct complex objects step-by-step. It separates the construction logic from the object’s representation, enabling the creation of different versions or configurations of an object using the same building process.

---

## 🧠 When to Use

Use the Builder pattern when:

- An object requires **many optional fields** or **combinations of configuration**.
- You want to **avoid long or telescoping constructors**.
- You need to **construct multiple representations** of the same object.
- You want **fluent or readable object construction**.

---

## 🧱 Key Concepts

- **Product**: The complex object being built (e.g., `House`, `HttpRequest`).
- **Builder Interface**: Defines the steps to build the product.
- **Concrete Builder**: Implements the steps to create a specific version.
- **Director** *(optional)*: Defines the order in which to call builder methods.

---

## 💻 Code Example 1 – House Builder

```csharp
// Product
public class House {
    public string Foundation { get; set; }
    public string Structure { get; set; }
    public string Roof { get; set; }
    public bool HasGarage { get; set; }
}

// Builder Interface
public interface IHouseBuilder {
    void BuildFoundation();
    void BuildStructure();
    void BuildRoof();
    void BuildGarage();
    House GetHouse();
}

// Concrete Builder
public class ModernHouseBuilder : IHouseBuilder {
    private House _house = new House();
    public void BuildFoundation() => _house.Foundation = "Concrete Slab";
    public void BuildStructure() => _house.Structure = "Steel and Glass";
    public void BuildRoof() => _house.Roof = "Flat Roof";
    public void BuildGarage() => _house.HasGarage = true;
    public House GetHouse() => _house;
}

// Director
public class HouseDirector {
    private IHouseBuilder _builder;
    public HouseDirector(IHouseBuilder builder) => _builder = builder;
    public void ConstructHouse() {
        _builder.BuildFoundation();
        _builder.BuildStructure();
        _builder.BuildRoof();
        _builder.BuildGarage();
    }
}

// Usage
var builder = new ModernHouseBuilder();
var director = new HouseDirector(builder);
director.ConstructHouse();
House house = builder.GetHouse();
