import java.util.*;
public class areasquare {
    public static double calculateArea(double side) {
        return side * side;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double side = sc.nextDouble();
        double area = calculateArea(side);
        System.out.println("Area of square with side " + side + " is: " + area);
    }
}