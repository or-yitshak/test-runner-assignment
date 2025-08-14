using System;

namespace TestFramework
{
    public static class Assert
    {
        public static void IsTrue(bool condition, string message = "Assertion failed")
        {
            if (!condition)
                throw new Exception(message);
        }

        public static void AreEqual(object expected, object actual, string message = null)
        {
            if (!Equals(expected, actual))
                throw new Exception(message ?? $"Expected: {expected}, Actual: {actual}");
        }
    }
}