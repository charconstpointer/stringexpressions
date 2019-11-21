namespace R2D2.Parser
{
    public static class ParserFactory
    {
        public static IExpressionParser Create() => new ExpressionParser();
    }
}