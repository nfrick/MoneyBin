using System;

namespace MoneyBin {
    public static class ExtensionMethods {
        public static string Key(this Tuple<string, string> value) {
            var x = value.ToString();
            return value.Item1 + "-" + value.Item2;
        }
    }
}
