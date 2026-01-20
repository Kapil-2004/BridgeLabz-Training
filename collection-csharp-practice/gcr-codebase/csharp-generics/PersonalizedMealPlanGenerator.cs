using System;
using System.Collections.Generic;

//
// Interface for meal plans
//
public interface IMealPlan
{
    string Category { get; }
    int Calories { get; }
    void ShowMeal();
}

//
// Meal plan implementations
//
public class VegetarianMeal : IMealPlan
{
    public string Category => "Vegetarian";
    public int Calories { get; private set; }

    public VegetarianMeal(int calories)
    {
        Calories = calories;
    }

    public void ShowMeal()
    {
        Console.WriteLine($"Vegetarian Meal | Calories: {Calories}");
    }
}

public class VeganMeal : IMealPlan
{
    public string Category => "Vegan";
    public int Calories { get; private set; }

    public VeganMeal(int calories)
    {
        Calories = calories;
    }

    public void ShowMeal()
    {
        Console.WriteLine($"Vegan Meal | Calories: {Calories}");
    }
}

public class KetoMeal : IMealPlan
{
    public string Category => "Keto";
    public int Calories { get; private set; }

    public KetoMeal(int calories)
    {
        Calories = calories;
    }

    public void ShowMeal()
    {
        Console.WriteLine($"Keto Meal | Calories: {Calories}");
    }
}

public class HighProteinMeal : IMealPlan
{
    public string Category => "High Protein";
    public int Calories { get; private set; }

    public HighProteinMeal(int calories)
    {
        Calories = calories;
    }

    public void ShowMeal()
    {
        Console.WriteLine($"High Protein Meal | Calories: {Calories}");
    }
}

//
// Generic Meal class with constraint
//
public class Meal<T> where T : IMealPlan
{
    public T MealPlan { get; set; }

    public Meal(T mealPlan)
    {
        MealPlan = mealPlan;
    }

    public void DisplayMeal()
    {
        MealPlan.ShowMeal();
    }
}

//
// Generic methods for validation and generation
//
public static class MealService
{
    public static void GenerateMealPlan<T>(Meal<T> meal)
        where T : IMealPlan
    {
        if (meal.MealPlan.Calories < 200)
        {
            Console.WriteLine("Invalid meal plan: Calories too low.");
            return;
        }

        Console.WriteLine($"Meal plan generated successfully for {meal.MealPlan.Category}");
        meal.DisplayMeal();
    }
}

//
// Main Program
//
class PersonalizedMealPlanGenerator
{
    static void Main()
    {
        Meal<VegetarianMeal> vegMeal =
            new Meal<VegetarianMeal>(new VegetarianMeal(450));

        Meal<VeganMeal> veganMeal =
            new Meal<VeganMeal>(new VeganMeal(400));

        Meal<KetoMeal> ketoMeal =
            new Meal<KetoMeal>(new KetoMeal(600));

        Meal<HighProteinMeal> proteinMeal =
            new Meal<HighProteinMeal>(new HighProteinMeal(550));

        Console.WriteLine("=== Generating Meal Plans ===");
        MealService.GenerateMealPlan(vegMeal);
        MealService.GenerateMealPlan(veganMeal);
        MealService.GenerateMealPlan(ketoMeal);
        MealService.GenerateMealPlan(proteinMeal);
    }
}
