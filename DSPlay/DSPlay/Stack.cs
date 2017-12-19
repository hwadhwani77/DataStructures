using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPlay
{
    public class Stack<T>
    {
        int top, MAX;
        T[] inputArray;

        public Stack()
        {
            this.MAX = 100;
            inputArray = new T[this.MAX];
            top = -1;
        }

        public Stack(int capacity)
        {
            this.MAX = capacity;
            inputArray = new T[this.MAX];
            top = -1;
        }

        public bool isEmpty()
        {
            return (top < 0);
        }

        public bool push(T data)
        {
            if (top >= this.MAX)
                return false;
            else
            {
                inputArray[++top] = data;
                return true;
            }
        }

        public T pop()
        {
            if (top < 0)
                return default(T);
            else
                return inputArray[top--];
        }

        public T peek()
        {
            if (top < 0)
                return default(T);
            else
                return inputArray[top];
        }

        public string infixToPostFix(string str)
        {
            String result = "";

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if (char.IsLetterOrDigit(c))
                    result += c;

                else if (c == '(')
                    stack.push(c);

                else if (c == ')')
                {
                    while (!stack.isEmpty() && stack.peek() != '(')
                        result += stack.pop();
                    if (!stack.isEmpty() && stack.peek() != '(')
                        return "Invalid Expression";
                    else
                        stack.pop();
                }
                else
                {
                    while (!stack.isEmpty() && getPrecedence(c) <= getPrecedence(stack.peek()))
                        result += stack.pop();

                    stack.push(c);
                }
            }

            while (!stack.isEmpty())
                result += stack.pop();

            return result;
        }

        public int postFixEvaluation(string str)
        {
            int result = -1;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < str.Length; i++)
            {
                int c = -1;
                if (Int32.TryParse(str[i].ToString(), out c))
                    stack.push(c);
                else
                {
                    if (!stack.isEmpty())
                    {
                        int val1 = stack.pop();
                        int val2 = stack.pop();

                        switch (str[i])
                        {
                            case '+':
                                stack.push(val2 + val1);
                                break;

                            case '-':
                                stack.push(val2 - val1);
                                break;

                            case '*':
                                stack.push(val2 * val1);
                                break;

                            case '/':
                                stack.push(val2 / val1);
                                break;

                        }
                    }
                }
            }

            return stack.pop();
        }

        public string reverseString(string str)
        {
            string result = string.Empty;
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                stack.push(str[i]);
            }

            while (!stack.isEmpty())
            {
                result += stack.pop();
            }
            return result;
        }

        public bool balancedParanthesis(string str)
        {
            bool result = true;

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{' || str[i] == '[' || str[i] == '(')
                {
                    stack.push(str[i]);
                }
                else if (str[i] == '}' || str[i] == ']' || str[i] == ')')
                {
                    char c = stack.pop();
                    switch (c)
                    {
                        case '{':
                            if (str[i] == '}')
                            {
                                //Do nothing
                            }
                            break;

                        case '[':
                            if (str[i] == ']')
                            {
                                //Do nothing
                            }
                            break;

                        case '(':
                            if (str[i] == ')')
                            {
                                //Do nothing
                            }
                            break;

                        default:
                            return false;
                    }
                }
            }

            if (!stack.isEmpty())
                result = false;

            return result;
        }

        public void printNextGreaterElement(int[] array)
        {
            int len = array.Length, i = 1, next, element;
            Stack<int> stack = new Stack<int>(len);

            stack.push(array[0]);

            for (i = 1; i < len; i++)
            {
                next = array[i];

                if (!stack.isEmpty())
                {
                    element = stack.pop();

                    while (element < next)
                    {
                        Console.WriteLine("Element {0} --> {1}", element, next);
                        if (stack.isEmpty())
                            break;

                        element = stack.pop();
                    }

                    if (element > next)
                        stack.push(element);
                }

                stack.push(next);
            }

            while (!stack.isEmpty())
            {
                Console.WriteLine("Element {0} --> -1", stack.pop());
            }
        }

        public void reverseStackRecursively(Stack<int> stack)
        {
            if (stack.top >= 0)
            {
                int i = stack.peek();
                stack.pop();
                reverseStackRecursively(stack);
                insertAtBottom(i, stack);
            }
        }

        public void sortStackRecursively(Stack<int> stack)
        {
            if (!stack.isEmpty())
            {
                int temp = stack.pop();
                sortStackRecursively(stack);
                insertSorted(temp, stack);
            }
        }

        private void insertSorted(int data, Stack<int> stack)
        {
            if (stack.isEmpty() || data > stack.peek())
            {
                stack.push(data);
                return;
            }
            int temp = stack.pop();
            insertSorted(stack.peek(), stack);
            stack.push(temp);
        }


        private void insertAtBottom(int data, Stack<int> stack)
        {
            if (stack.isEmpty())
                stack.push(data);
            else
            {
                int i = stack.peek();
                stack.pop();
                insertAtBottom(data, stack);

                stack.push(i);
            }
        }
        private int getPrecedence(char c)
        {
            switch (c)
            {

                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;

                default:
                    return 0;
            }
        }
    }
}
