import java.util.Scanner;

public class palindrome {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a string: ");
        String input = scanner.nextLine();
        scanner.close();
        
        String cleaned = input.replaceAll("[^a-zA-Z0-9]", "").toLowerCase();
        boolean isPalindrome = cleaned.equals(new StringBuilder(cleaned).reverse().toString());
        
        System.out.println("Is palindrome: " + isPalindrome);
    }
}
