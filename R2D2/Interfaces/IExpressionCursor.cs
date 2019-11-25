﻿using System;

namespace R2D2.Interfaces
{
    /// <summary>
    /// Allows to walk over an expression
    /// </summary>
    public interface IExpressionCursor
    {
        /// <summary>
        /// Returns current character and increments the cursor's position
        /// </summary>
        /// <returns></returns>
        int Read();
    }
}