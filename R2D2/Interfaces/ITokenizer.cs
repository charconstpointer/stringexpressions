﻿using R2D2.Parser;

 namespace R2D2.Interfaces
{
    public interface ITokenizer
    {
        void MoveNext();
        public Token Token { get; }
        public double Number { get; }
    }
}