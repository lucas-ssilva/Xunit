﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTeste._Util
{
   public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string message)
        {
            if(exception.Message == message)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Esperava a mensagem '{message}'");
            }
        }
    }
}
