import java.util.*;
public class areatriangle {
    public static double calculateArea(double base, double height) {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter base: ");
        base = sc.nextDouble();
        System.out.print("Enter height: ");
        height = sc.nextDouble();
        sc.close();
        return (base * height) / 2;
    }

    public static void main(String[] args) {
        double base = 10;
        double height = 5;
        double area = calculateArea(base, height);
        System.out.println("Area of triangle: " + area);
    }
}
