class CustomStack
{
    private int[] stack;
    private int top;

    public CustomStack(int size)
    {
        stack = new int[size];
        top = -1;
    }

    public void Push(int value)
    {
        if (top == stack.Length - 1)
        {
            System.Console.WriteLine("Stack Overflow");
            return;
        }

        stack[++top] = value;
    }

    public int? Peek()
    {
        if (top == -1)
            return null;

        return stack[top];
    }

    public bool IsEmpty()
    {
        return top == -1;
    }
}
