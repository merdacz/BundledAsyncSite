namespace BundledAsyncSite.Host.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;

    public static class Assume
    {
        private static IDictionary<Regex, string> replacements
            = new Dictionary<Regex, string>()
                  {
                      { new Regex("value\\([^)]*\\)\\."), string.Empty },
                      { new Regex("\\(\\)\\."), string.Empty },
                      { new Regex("\\(\\)\\ =>"), string.Empty },
                      { new Regex("Not"), "!" }
                  };
        
        /// <summary>
        /// Assumes that the evaluated expression is true. If not reports an error.  
        /// </summary>
        /// <exception cref="InvalidOperationException" />
        /// <param name="assertion">The assertion to evaluate.</param>
        public static void That(Expression<Func<bool>> assertion)
        {
            var evaluate = assertion.Compile();
            var evaluatedValue = evaluate();
            if (!evaluatedValue)
            {
                throw new InvalidOperationException(
                    string.Format("'{0}' is not met.", PrepareErrorMessage(assertion.ToString())));
            }
        }

        private static string PrepareErrorMessage(string expression)
        {
            var result = expression;
            foreach (var pattern in replacements)
            {
                result = pattern.Key.Replace(result, pattern.Value);
            }

            return result.Trim(); 
        }
    }
}