using System;

public static class Thrower 
{
    public static void Main(String[] args) {
        // throwing some handled exceptions
        try {
            throw new InvalidOperationException("ex1");
        } catch (InvalidOperationException ex) {
            Console.WriteLine("Handled exception: {0}", ex);
        }
        
        try {
            throw new ArgumentNullException("ex2");
        } catch (ArgumentNullException ex) {
            Console.WriteLine("Handled exception: {0}", ex);
        }
        
        throw new NotImplementedException("ex3");
    }
}